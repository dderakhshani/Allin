using AutoMapper;

namespace Allin.Common.Utilities.Mappings
{
    public interface IMapFrom<Entity, Model>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(Entity), GetType()).ReverseMap();

    }
}
