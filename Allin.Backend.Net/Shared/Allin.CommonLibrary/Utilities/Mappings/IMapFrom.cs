using AutoMapper;

namespace Allin.Common.Utilities.Mappings
{
    public interface IMapFrom<Entity, Model>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(Entity), GetType()).ReverseMap();


        Entity ToEntity(IMapper _mapper);

        Model FromEntity(Entity entity, IMapper mapper);
    }
}
