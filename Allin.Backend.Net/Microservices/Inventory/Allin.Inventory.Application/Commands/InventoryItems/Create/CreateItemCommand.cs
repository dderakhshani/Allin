using Allin.Common.Utilities.Mappings;
using Allin.Inventory.Infrastructure.Persistence;
using AutoMapper;
using MediatR;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allin.Inventory.Application.Commands.InventoryCategories.Create
{
    public class CreateItemCommand : IRequest<bool>, IMapFrom<InventoryItem, CreateItemCommandHandler>
    {
        public long? ParentId { get; set; }
        public string ItemTitle { get; set; }
        public string Code { get; set; }
        public string? Code2 { get; set; }
        public string? Code3 { get; set; }
        public string? Code4 { get; set; }
        public long CategoryId { get; set; }
        public long StatusBaseId { get; set; }
        public long MeasureUnitId { get; set; }
        public long ItemTypeId { get; set; }
        public string? Description { get; set; }
        public string? Manufacturer { get; set; }
        public string? ModelNumber { get; set; }
        public int LifeTimeHours { get; set; }
        public IEnumerable<CreatePropertyValuesCommandArg> PropertyValues { get; set; }

    }

    public class CreatePropertyValuesCommandArg : IRequest<bool>, IMapFrom<InventoryPropertyValue, CreatePropertyValuesCommandArg>
    {
        public long ItemId { get; set; }
        public long CategoryPropertyId { get; set; }
        public long? ValuePropertyItemId { get; set; }
        public string Value { get; set; }
    }

}
