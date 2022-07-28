using exercises.Queries.WeekendCalendar;
using exercises.Services.Interfaces;
using MediatR;

namespace exercises.Handlers.WeekendCalendar
{
    public class GetDayQueryHandler : IRequestHandler<GetDayQuery, Data.Models.WeekendCalendar>
    {
        private readonly IWeekendCalendarService _WeekendCalendarService;
        public GetDayQueryHandler(IWeekendCalendarService wcs)
        {
            _WeekendCalendarService = wcs;
        }

        public Task<Data.Models.WeekendCalendar> Handle(GetDayQuery request, CancellationToken cancellationToken)
        {
            return _WeekendCalendarService.GetDay(request.Date);
        }
    }
}
