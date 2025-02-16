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
    public class CreateCategoryCommand : IRequest<bool>, IMapFrom<InventoryCategory, CreateCategoryCommandHandler>
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public IEnumerable<CreateCategoryPropertiesCommandArg>? Properties { get; set; }

        //public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<BaseValue, CreateBaseValueCommand>()
        //          .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.BaseValueItems))
        //          .ReverseMap();
        //}
    }

    public class CreateCategoryPropertiesCommandArg : IRequest<bool>, IMapFrom<InventoryCategoryProperty, CreateCategoryPropertiesCommandArg>
    {
        public string Title { get; set; }
        public string UniqueName { get; set; }
        public long CategoryId { get; set; }
        public IEnumerable<CreateCategoryPropertyItemsCommandArg>? Items { get; set; }
    }
    public class CreateCategoryPropertyItemsCommandArg : IRequest<bool>, IMapFrom<InventoryCategoryPropertyItem, CreateCategoryPropertyItemsCommandArg>
    {
        public string Title { get; set; }
        public string UniqueName { get; set; }
        public string Code { get; set; }
    }
}
