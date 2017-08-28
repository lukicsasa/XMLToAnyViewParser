using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static UserModel Map(User user)
        {
            if (user == null) return null;

            var userModel = new UserModel
            {
                
            };
            return userModel;
        }
    }
}
