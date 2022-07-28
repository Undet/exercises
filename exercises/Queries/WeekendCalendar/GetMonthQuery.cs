using MediatR;

namespace exercises.Queries.WeekendCalendar
{
    public class GetMonthQuery : IRequest<IEnumerable<Data.Models.WeekendCalendar>>
    {
        public DateTime Date { get; set; }
    }
}
