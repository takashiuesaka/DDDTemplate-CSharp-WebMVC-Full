using Sample.Core.domain.shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.domain.model.dailyTimeRecord
{
    internal class Time : ValueObject<Time>
    {
        public DateTime CalendarDateTime { get; }

        private Time(DateTime dateTime)
        {
            this.CalendarDateTime = dateTime;
        }

        public override bool SameValueAs(Time other)
        {
            return this.CalendarDateTime == other.CalendarDateTime;
        }

        public static Time Create(CalendarDate date, int hour, int minute)
        {
            var tempTime = date.DateTime.AddHours(hour).AddMinutes(minute);
            var newDateTime = date.DateTime.AddHours(5);

            if (date.DateTime <= tempTime && tempTime < newDateTime)
            {
                return new Time(date.DateTime.AddDays(1).AddHours(hour).AddMinutes(minute));
            }

            return new Time(date.DateTime.AddHours(hour).AddMinutes(minute));
        }

        public static Time Create(DateTime dateTime)
        {
            return new Time(dateTime);
        }
    }

}
