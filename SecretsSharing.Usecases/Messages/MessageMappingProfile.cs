using AutoMapper;
using SecretsSharing.Domain.StorageDataEntities;
using SecretsSharing.Usecases.Messages.UploadMessage;

namespace SecretsSharing.Usecases.Messages
{
    /// <summary>
    /// Message mapping profile.
    /// </summary>
    public class MessageMappingProfile : Profile
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public MessageMappingProfile()
        {
            // Entity -> Dto.

            // Command -> Entity.
            CreateMap<CreateMessageCommand, Message>().ReverseMap();
        }
    }
}