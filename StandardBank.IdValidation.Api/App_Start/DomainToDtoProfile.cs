using AutoMapper;
using StandardBank.IdValidation.Api.Models;
using StandardBank.IdValidation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StandardBank.IdValidation.Api
{
    public class DomainToDtoProfile: Profile
    {
        public DomainToDtoProfile()
        {
            CreateMap<Identification, IdentificationDto>()
                .ForMember(dest => dest.DateOfBirth, opts => opts.MapFrom(src => src.DateOfBirth.ToString("dd MMM yyyy")));
        }
    }
}