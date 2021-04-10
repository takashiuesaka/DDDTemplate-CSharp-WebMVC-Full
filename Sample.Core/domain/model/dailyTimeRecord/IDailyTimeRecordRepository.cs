using Sample.Core.domain.shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.domain.model.dailyTimeRecord
{
    internal interface IDailyTimeRecordRepository
    {
        IReadOnlyList<DailyTimeRecord> ListTimeRecording();

        DailyTimeRecord GetById(Identity id);

        void Update(DailyTimeRecord dailyTimeRecord);
    }
}
