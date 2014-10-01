using System;

namespace Yd.Server.Core.Model
{
    public class HolidayCalendar
    {
        public int HolidayCalendarId { get; set; }
        public string Name { get; set; }
        public DateTime Day { get; set; }
        public int? CalendarId { get; set; }
        public virtual Calendar Calendar { get; set; }
    }
}
