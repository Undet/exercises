using MediatR;

namespace exercises.Queries.WeekendCalendar
{
    public class GetYearQuery : IRequest<IEnumerable<Data.Models.WeekendCalendar>>
    {
        public DateTime Date { get; set; }
    }
}
