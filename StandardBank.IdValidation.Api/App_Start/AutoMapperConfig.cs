using AutoMapper;
using StandardBank.IdValidation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StandardBank.IdValidation.Api
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<DomainToDtoProfile>();
            });
        }

        public static TDestination Map<TDestination, TSource>(TSource source)
        {
            var result = Mapper.Map<TDestination>(source);
            return result;
        }
    }
}