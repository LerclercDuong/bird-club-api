﻿using AutoMapper;
using BirdClubAPI.Domain.DTOs.Response.Member;
using BirdClubAPI.Domain.Entities;

namespace BirdClubAPI.PresentationLayer.Configurations.AutoMapper.Modules
{
    public static class MemberModule
    {
        public static void ConfigMemberModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Member, MemberResponseModel>()
                .ForMember(dest => dest.MemberId, opts => opts.MapFrom(src => src.UserId))
                .ForMember(dest => dest.DisplayName, opts => opts.MapFrom(src => src.User.DisplayName))
                .ReverseMap();
        }
    }
}
