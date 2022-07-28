using exercises.Queries.WeekendCalendar;
using exercises.Services.Interfaces;
using MediatR;

namespace exercises.Handlers.WeekendCalendar
{
    public class GetYearQueryHandler : IRequestHandler<GetYearQuery, IEnumerable<Data.Models.WeekendCalendar>>
    {
        private readonly IWeekendCalendarService _WeekendCalendarService;
        public GetYearQueryHandler(IWeekendCalendarService wcs)
        {
            _WeekendCalendarService = wcs;
        }

        public Task<IEnumerable<Data.Models.WeekendCalendar>> Handle(GetYearQuery request, CancellationToken cancellationToken)
        {
            return _WeekendCalendarService.GetYear(request.Date);
        }
    }
}
