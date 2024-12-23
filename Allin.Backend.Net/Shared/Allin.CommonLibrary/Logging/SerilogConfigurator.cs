using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using ServiceStack;

namespace Allin.Common.Logging;

public static class SerilogConfigurator
{
    public const string LogDbConnectionStringName = "Log";
    private const string CompanyLogKeyPrefix = "CompanyConnectionStringName";

    public static string CompanyLogKey(string companyConnectionStringName)
    {
        return $"{CompanyLogKeyPrefix}_{companyConnectionStringName.ToLower()}";
    }

    public static void ConfigWithoutLogHistory(IConfiguration configuration)
    {
        new LoggerConfiguration().ReadFrom.Configuration(configuration);
    }

    public static void ConfigWithLogHistory(IConfiguration configuration)
    {
        var serilogConfiguration = new LoggerConfiguration()
                                .ReadFrom.Configuration(configuration);

        var logDbConnectionString = configuration.GetConnectionString(LogDbConnectionStringName);

        configuration.GetSection("ConnectionStrings").GetChildren().Where(c => c.Key != LogDbConnectionStringName).Each(connectionStringSection =>
        {
            configCompanyHistoryLogger(serilogConfiguration, logDbConnectionString, connectionStringSection.Key);
        });

        Log.Logger = serilogConfiguration.CreateLogger();
    }

    private static void configCompanyHistoryLogger(LoggerConfiguration serilogConfiguration, string connectionString, string tableName)
    {
        var columnOptions = new ColumnOptions
        {
            AdditionalColumns = new Collection<SqlColumn>
             {
                new SqlColumn { ColumnName = "Entity", DataType = SqlDbType.VarChar, DataLength = 550, NonClusteredIndex = true },

                new SqlColumn { ColumnName = "Key", DataType = SqlDbType.VarChar, DataLength = 48, NonClusteredIndex = true },

                new SqlColumn { ColumnName = "Operation", DataType = SqlDbType.VarChar, DataLength = 32 },

                new SqlColumn { ColumnName = "UserName", DataType = SqlDbType.VarChar, DataLength = 127 },

                new SqlColumn { ColumnName = "UserFullName", DataType = SqlDbType.NVarChar, DataLength = 256 },

                new SqlColumn { ColumnName = "UserId", DataType = SqlDbType.Int },

                new SqlColumn { ColumnName = "RequestPath", DataType = SqlDbType.NVarChar, DataLength = 512 },

                new SqlColumn { ColumnName = "RequestMethod", DataType = SqlDbType.NVarChar, DataLength = 10 }
            },
            DisableTriggers = false,
            ClusteredColumnstoreIndex = false
        };

        columnOptions.Store.Remove(StandardColumn.MessageTemplate);
        columnOptions.Store.Remove(StandardColumn.Properties);
        columnOptions.Store.Remove(StandardColumn.Exception);
        columnOptions.Store.Remove(StandardColumn.Level);

        var companyLogKey = CompanyLogKey(tableName);
        serilogConfiguration.WriteTo.Logger(config =>
        config.Filter.ByIncludingOnly(evt => evt.Properties.ContainsKey(companyLogKey))
                    .Enrich.FromLogContext()
                    .WriteTo.MSSqlServer(
                     connectionString,
                     sinkOptions: new MSSqlServerSinkOptions { TableName = $"AuditLog{tableName}", AutoCreateSqlTable = false },
                     columnOptions: columnOptions
                     ));
    }
}

