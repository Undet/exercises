using AutoMapper;
using exercises.DTO.Models;
using exercises.Queries.WeekendCalendar;
using exercises.Services.Implementations;
using exercises.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace exercises.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeekendCalendarController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<WeekendCalendarController> _logger;
        private readonly IMapper _mapper;
        private readonly IWeekendCalendarService _calendarService;

        public WeekendCalendarController(IMediator mediator, ILogger<WeekendCalendarController> logger, IMapper mapper, IWeekendCalendarService calendarService)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
            _calendarService = calendarService;
        }

        [HttpGet]
        [Route("Year")]
        public async Task<IActionResult> GetYear(DateTime dateTime)
        {
            var dates = await _mediator.Send(new GetYearQuery{ Date = dateTime });
            var result = _mapper.Map<IEnumerable<WeekendCalendarDTO>>(dates);
            return Ok(result);
        }

        [HttpGet]
        [Route("Month")]
        public async Task<IActionResult> GetMonth(DateTime dateTime)
        {
            var dates = await _mediator.Send(new GetMonthQuery { Date = dateTime });
            var result = _mapper.Map<IEnumerable<WeekendCalendarDTO>>(dates);
            return Ok(result);
        }

        [HttpGet]
        [Route("Day")]
        public async Task<IActionResult> GetDay(DateTime dateTime)
        {
            var date = await _mediator.Send(new GetDayQuery { Date = dateTime });
            var result = _mapper.Map<WeekendCalendarDTO>(date);
            return Ok(result);
        }

    }
}
