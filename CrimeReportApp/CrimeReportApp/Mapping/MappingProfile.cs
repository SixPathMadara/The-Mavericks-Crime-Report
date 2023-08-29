using AutoMapper;
using CrimeReportApp.Models;
using CrimeReportApp.Data;

namespace CrimeReportApp.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, User>().ReverseMap();
            CreateMap<CrimeEntity, CrimeReport>().ReverseMap();
            CreateMap<TypeEntity, CrimeType>().ReverseMap();
            CreateMap<AttachmentEntity, Attachment>().ReverseMap();
            CreateMap<NotificationEntity, Notification>().ReverseMap();
            CreateMap<NotificationEntity, Notification>().ReverseMap();
        }
    }
}
