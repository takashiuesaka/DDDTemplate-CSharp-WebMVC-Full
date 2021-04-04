using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.domain.model.dailyTimeRecord
{
    internal interface IDailyTimeRecordRepository
    {
        IReadOnlyList<DailyTimeRecord> ListTimeRecording();
    }
}
