using exercises.Data.Models;
using exercises.Services.Interfaces;

namespace exercises.Services.Implementations
{
    public class WeekendCalendarService : IWeekendCalendarService
    {
        private Uri apiUri = new Uri("https://isdayoff.ru/api/getdata?");
        private HttpClient client = new HttpClient();

        public async Task<WeekendCalendar> GetDay(DateTime dateTime)
        {
            string scheme = $"year={dateTime.Year}&month={dateTime.Month}&day={dateTime.Day}";
            HttpResponseMessage response = await client.GetAsync(apiUri + scheme);
            var respounseString = await response.Content.ReadAsStringAsync();
            bool isDayOf = respounseString == "1";

            var result = new WeekendCalendar
            {
                Date = dateTime.Date,
                DayOfWeek = dateTime.DayOfWeek,
                IsDayOff = isDayOf
            };

            return result;
            
        }

        public async Task<IEnumerable<WeekendCalendar>> GetMonth(DateTime dateTime)
        {
            string scheme = $"year={dateTime.Year}&month={dateTime.Month}&";
            HttpResponseMessage response = await client.GetAsync(apiUri + scheme);
            var respounseString = await response.Content.ReadAsStringAsync();
            WeekendCalendar[] result = CreateDateArrFromRespounse(ref dateTime, respounseString);

            return result;
        }
        

        public async Task<IEnumerable<WeekendCalendar>> GetYear(DateTime dateTime)
        {
            string scheme = $"year={dateTime.Year}";
            HttpResponseMessage response = await client.GetAsync(apiUri + scheme);
            var respounseString = await response.Content.ReadAsStringAsync();

            var result = CreateDateArrFromRespounse(ref dateTime, respounseString);

            return result;
        }

        private static WeekendCalendar[] CreateDateArrFromRespounse(ref DateTime dateTime, string respounseString)
        {
            WeekendCalendar[] result = new WeekendCalendar[respounseString.Length];
            for (int i = 0; i < respounseString.Length; i++)
            {
                char responseChar = respounseString[i];
                bool isDayOf = responseChar == '1';

                result[i] = new WeekendCalendar
                {
                    Date = dateTime.Date,
                    DayOfWeek = dateTime.DayOfWeek,
                    IsDayOff = isDayOf
                };
                dateTime = dateTime.AddDays(1);
            }

            return result;
        }
    }
}
