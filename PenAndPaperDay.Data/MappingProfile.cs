using System.Collections.Generic;
using AutoMapper;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.Entites;

namespace PenAndPaperDay.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TimeRange, TimeRangeDto>();
            CreateMap<Tag, TagDto>();
            CreateMap<Language, LanguageDto>();
            CreateMap<ErrorLogEntry, ErrorLogEntryDto>();
            CreateMap<User, UserDto>();
            CreateMap<UserOnOfferedGame, UserOnOfferedGameDto>();
            CreateMap<OfferedGameOnTag, OfferedGameOnTagDto>();
            CreateMap<OfferedGame, OfferedGameDto>();
            CreateMap<Newsletter, NewsletterDto>();
            CreateMap<UserOnTimeRange, UserOnTimeRangeDto>();

            CreateMap<TimeRangeDto, TimeRange>();
            CreateMap<TagDto, Tag>();
            CreateMap<LanguageDto, Language>();
            CreateMap<ErrorLogEntryDto, ErrorLogEntry>();
            CreateMap<UserDto, User>();
            CreateMap<UserOnOfferedGameDto, UserOnOfferedGame>();
            CreateMap<OfferedGameOnTagDto, OfferedGameOnTag>();
            CreateMap<OfferedGameDto, OfferedGame>();
            CreateMap<NewsletterDto, Newsletter>();
            CreateMap<UserOnTimeRangeDto, UserOnTimeRange>();
        }
    }
}
