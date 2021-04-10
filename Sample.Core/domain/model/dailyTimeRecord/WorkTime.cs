using Sample.Core.domain.shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.domain.model.dailyTimeRecord
{
    class WorkTime : ValueObject<WorkTime>
    {
        private Time StartTime { get; }

        private Time EndTime { get; }

        public WorkTime (Time startTime, Time endTime)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        public TimeSpan Value
        {
            get
            {
                return this.EndTime.Subsract(this.StartTime);
            }
        }

        public TimeSpan OverTime
        {
            get
            {
                Duration normalWorked = new Duration(TimeSpan.FromHours(8));
                Duration overTime = this.Value.Subtract(normalWorked);


            }
        }

        public TimeSpan BreakTime
        {
            get
            {

            }
        }

        public override bool SameValueAs(WorkTime other)
        {
            return this.StartTime.SameValueAs(other.StartTime) && this.EndTime.SameValueAs(other.EndTime);
        }

    }
}
