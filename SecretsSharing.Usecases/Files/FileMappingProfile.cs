﻿using AutoMapper;
using SecretsSharing.Domain.StorageDataEntities;
using SecretsSharing.Usecases.Files.UploadFile;

namespace SecretsSharing.Usecases.Files
{
    public class FileMappingProfile : Profile
    {
        public FileMappingProfile()
        {
            // Entity -> Dto.

            // Command -> Entity.
            CreateMap<UploadFileCommand, File>()
                .ForMember(file => file.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(file => file.AutoDelete, opt => opt.MapFrom(src => src.AutoDelete));
        }
    }
}