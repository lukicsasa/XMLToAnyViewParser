using AutoMapper;
using XMLToAnyViewParser.Common.Models;
using XMLToAnyViewParser.Entities;

namespace XMLToAnyViewParser.Common.Helpers
{
    public class Mapper
    {
        public static TDestination AutoMap<TSource, TDestination>(TSource source)
            where TDestination : class
            where TSource : class
        {
            var config = new MapperConfiguration(c => c.CreateMap<TSource, TDestination>());
            var mapper = config.CreateMapper();
            var result = mapper.Map<TDestination>(source);

            return result;
        }
    }
}
