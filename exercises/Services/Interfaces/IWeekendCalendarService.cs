using exercises.Data.Models;

namespace exercises.Services.Interfaces
{
    public interface IWeekendCalendarService
    {
        Task<IEnumerable<WeekendCalendar>> GetYear(DateTime dateTime);
        Task<IEnumerable<WeekendCalendar>> GetMonth(DateTime dateTime);
        Task<WeekendCalendar> GetDay(DateTime dateTime);

    }
}
