using exercises.Queries.WeekendCalendar;
using exercises.Services.Interfaces;
using MediatR;

namespace exercises.Handlers.WeekendCalendar
{
    public class GetMonthQueryHandler : IRequestHandler<GetMonthQuery, IEnumerable<Data.Models.WeekendCalendar>>
    {
        private readonly IWeekendCalendarService _WeekendCalendarService;
        public GetMonthQueryHandler(IWeekendCalendarService wcs)
        {
            _WeekendCalendarService = wcs;
        }

        public Task<IEnumerable<Data.Models.WeekendCalendar>> Handle(GetMonthQuery request, CancellationToken cancellationToken)
        {
            return _WeekendCalendarService.GetMonth(request.Date);
        }
    }
}
