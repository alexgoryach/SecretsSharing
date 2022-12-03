﻿using AutoMapper;
using SecretsSharing.Domain.Users;
using SecretsSharing.Usecases.Common.Dtos.UserAuthentication;

namespace SecretsSharing.Usecases.Users
{
    public class UsersMappingProfile : Profile
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public UsersMappingProfile()
        {
            // Entity -> Dto.
            CreateMap<User, UserDto>().ReverseMap();

            // Command -> Entity.
        }
    }
}