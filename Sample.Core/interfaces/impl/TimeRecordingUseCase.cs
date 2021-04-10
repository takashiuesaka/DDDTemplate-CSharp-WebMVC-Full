using Sample.Core.application;
using Sample.Core.domain.model.dailyTimeRecord;
using Sample.Core.domain.shared;
using Sample.Core.interfaces.dto;
using Sample.Core.interfaces.impl.modelConverter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.interfaces.impl
{
    internal class TimeRecordingUseCase : ITimeRecordingUseCase
    {
        private IDailyTimeRecordRepository DailyTimeRecordRepository { get; }

        private ITimeRecordingService TimeRecordingService { get;  }

        public TimeRecordingUseCase(
            ITimeRecordingService timeRecordingService,
            IDailyTimeRecordRepository dailyTtimeRecordRepository)
        {
            this.TimeRecordingService = timeRecordingService;
            this.DailyTimeRecordRepository = dailyTtimeRecordRepository;
        }

        public IReadOnlyList<DailyTimeRecordDto> ListDailyRecord()
        {
            IReadOnlyList<DailyTimeRecord> listDailyTimeRecord =  this.DailyTimeRecordRepository.ListTimeRecording();

            return DailyTimeRecordConverter.ToListDto(listDailyTimeRecord);
        }

        public void UpdateDailyTime(string id, DateTime date, string startTime, string endTime)
        {
            this.TimeRecordingService.UpdateDailyTime(new Identity(id), new Date(date), new Time(startTime), new Time(endTime));
        }
    }
}
