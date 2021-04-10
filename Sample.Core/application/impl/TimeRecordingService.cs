﻿using Sample.Core.domain.model.dailyTimeRecord;
using Sample.Core.domain.shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.application.impl
{
    internal class TimeRecordingService : ITimeRecordingService
    {
        private IDailyTimeRecordRepository DailyTimeRecordRepository { get; }

        public TimeRecordingService(IDailyTimeRecordRepository dailyTimeRecordRepository)
        {
            this.DailyTimeRecordRepository = dailyTimeRecordRepository;
        }

        public void UpdateDailyTime(Identity id, Date date, Time startTime, Time endTime)
        {
            DailyTimeRecord dailyTimeRecord = this.DailyTimeRecordRepository.GetById(id);

            dailyTimeRecord.UpdateStartTime(startTime);
            dailyTimeRecord.UpdateEndTime(endTime);

            this.DailyTimeRecordRepository.Update(dailyTimeRecord);
        }
    }
}