using MediatR;

namespace exercises.Queries.WeekendCalendar
{
    public class GetDayQuery : IRequest<Data.Models.WeekendCalendar>
    {
        public DateTime Date { get; set; }
    }
}
