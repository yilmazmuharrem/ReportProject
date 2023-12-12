using AutoMapper;
using ReportProject.Entities.Dtos.Requests;
using ReportProject.Entities.Models;
using ReportProject.Entities.Models.Authorization;

namespace ReportProject.API.MappingProfiles
{
    public class RequestToDomain :Profile
    {
        public RequestToDomain()
        {


            CreateMap<PersonRequestDto, Person>()
                .ForMember(dest => dest.Name,opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname,opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1))
                .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

           CreateMap<UpdatePersonDto, Person>()
               .ForMember(dest => dest.Name,opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Surname,opt => opt.MapFrom(src => src.Surname))
               .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

          CreateMap<ReportRequestDto, Report>()
              .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.PersonId))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
              .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1))
              .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
              .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
              .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));


           CreateMap<UpdateReportDto, Report>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.BeginningTime, opt => opt.MapFrom(src => src.BeginningTime))
            .ForMember(dest => dest.FinishTime, opt => opt.MapFrom(src => src.FinishTime));


            CreateMap<LoginUserDto, User>()
           .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));
        }

    }

}
