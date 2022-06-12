using AutoMapper;
using Domain.Mapper;

namespace Tests.Mapper
{
    internal class MapperFactory
    {
        public static IMapper GetMapper()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(new[] {
            typeof(MappingProfile)
        }));

            return configuration.CreateMapper();
        }
    }
}
