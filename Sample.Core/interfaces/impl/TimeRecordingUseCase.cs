using Sample.Core.domain.model.dailyTimeRecord;
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

        public TimeRecordingUseCase(IDailyTimeRecordRepository dailyTtimeRecordRepository)
        {
            this.DailyTimeRecordRepository = dailyTtimeRecordRepository;
        }

        public IReadOnlyList<DailyTimeRecordDto> ListDailyRecord()
        {
            IReadOnlyList<DailyTimeRecord> listDailyTimeRecord =  this.DailyTimeRecordRepository.ListTimeRecording();

            return DailyTimeRecordConverter.ToListDto(listDailyTimeRecord);
        }
    }
}
