using Allin.Admin.Application.Models;
using Allin.Admin.Infrastructure.Persistence;
using Allin.Common.Utilities.Mappings;
using AutoMapper;
using MediatR;

namespace Allin.Admin.Application.Commands
{
    public class CreateBaseValueCommand : IRequest<bool>, IMapFrom<BaseValue, CreateBaseValueCommand>
    {

        public required string Title { get; set; }
        public required string UniqueName { get; set; }
        public string? Description { get; set; }

        public required IEnumerable<AddBaseValueItemCommand> Items { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BaseValue, CreateBaseValueCommand>()
                  .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.BaseValueItems))
                  .ReverseMap();
        }
    }
}