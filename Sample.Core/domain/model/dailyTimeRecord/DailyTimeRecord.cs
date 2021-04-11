using Sample.Core.domain.shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.domain.model.dailyTimeRecord
{
    internal class DailyTimeRecord : Entity<DailyTimeRecord>
    {

        public DailyTimeRecord(Identity identity, CalendarDate calendarDate, Time startTime, Time endTime, TimeSpan breakTime, TimeSpan workingHours, TimeSpan overtimeHours) : base(identity)
        {
            base.Id = identity;
            CalendarDate = calendarDate;
            StartTime = startTime;
            EndTime = endTime;
            BreakTime = breakTime;
            WorkingHours = workingHours;
            OvertimeHours = overtimeHours;
        }

        public CalendarDate CalendarDate { get; }

        public Time StartTime { get; private set; }

        public Time EndTime { get; private set; }

        internal void Recalcurate(Time startTime, Time endTime)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;

            TimeSpan fromStartToEndWorkingtime = endTime.CalendarDateTime - startTime.CalendarDateTime;

            if (fromStartToEndWorkingtime <= TimeSpan.FromHours(6))
            {
                this.BreakTime = TimeSpan.Zero;
            }

            if (TimeSpan.FromHours(6) < fromStartToEndWorkingtime && fromStartToEndWorkingtime <= TimeSpan.FromHours(8))
            {
                this.BreakTime = TimeSpan.FromMinutes(45);
            }

            if (TimeSpan.FromHours(8) < fromStartToEndWorkingtime)
            {
                this.BreakTime = TimeSpan.FromHours(1);
            }

            this.WorkingHours = fromStartToEndWorkingtime - this.BreakTime;

            if (TimeSpan.FromHours(8) < this.WorkingHours)
            {
                this.OvertimeHours = this.WorkingHours - TimeSpan.FromHours(8);
            }
            else
            {
                this.OvertimeHours = TimeSpan.Zero;
            }
        }

        public TimeSpan BreakTime { get; private set; }

        public TimeSpan WorkingHours { get; private set; }

        public TimeSpan OvertimeHours { get; private set; }
    }
}
