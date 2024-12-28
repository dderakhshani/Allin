using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Allin.Common.Utilities.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
            .Where(a => !a.IsDynamic)
            .SelectMany(a => a.GetExportedTypes());
            ApplyMappingsFromAssembly(types);
        }

        private void ApplyMappingsFromAssembly(IEnumerable<Type> types)
        {

            var mapperTypes = (from t in types
                               where t.GetInterfaces().Any(i =>
                          i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<,>)) && !t.IsAbstract
                               select t).ToList();

            foreach (var type in mapperTypes)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping", BindingFlags.NonPublic | BindingFlags.Instance);
                if (methodInfo == null)
                {
                    var interfaceType = type.GetInterface("IMapFrom`2");
                    if (interfaceType == null)
                    {
                        throw new Exception($"There is no interface 'IMapFrom`2' for {type}");
                    }
                    methodInfo = interfaceType.GetMethod("Mapping");
                }

                methodInfo?.Invoke(instance, new object[] { this });

            }
        }
    }
}