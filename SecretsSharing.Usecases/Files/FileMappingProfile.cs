using AutoMapper;
using SecretsSharing.Domain.StorageDataEntities;
using SecretsSharing.Usecases.Common.Dtos.File;
using SecretsSharing.Usecases.Files.UploadFile;

namespace SecretsSharing.Usecases.Files
{
    /// <summary>
    /// File mapping profile.
    /// </summary>
    public class FileMappingProfile : Profile
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public FileMappingProfile()
        {
            // Entity -> Dto.
            CreateMap<File, FileDto>();
            CreateMap<File, FileSummaryDto>();

            // Command -> Entity.
            CreateMap<UploadFileCommand, File>()
                .ForMember(file => file.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(file => file.AutoDelete, opt => opt.MapFrom(src => src.AutoDelete));
        }
    }
}