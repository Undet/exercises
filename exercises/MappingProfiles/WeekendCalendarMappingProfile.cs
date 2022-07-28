using AutoMapper;
using exercises.Data.Models;
using exercises.DTO.Models;

namespace exercises.MappingProfiles
{
    public class WeekendCalendarMappingProfile : Profile
    {
        public WeekendCalendarMappingProfile()
        {
            CreateMap<WeekendCalendar, WeekendCalendarDTO>();
        }
    }
}
