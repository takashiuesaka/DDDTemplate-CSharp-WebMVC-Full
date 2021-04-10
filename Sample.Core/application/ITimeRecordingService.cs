using Sample.Core.domain.model.dailyTimeRecord;
using Sample.Core.domain.shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.application
{
    internal interface ITimeRecordingService
    {
        void UpdateDailyTime(Identity identity, Date date, Time startTime, Time endTime);
    }
}
