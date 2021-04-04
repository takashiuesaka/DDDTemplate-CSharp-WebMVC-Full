using System;
using System.Collections.Generic;
using System.Text;
using Sample.Core.interfaces.dto;

namespace Sample.Core.interfaces
{
    public interface ITimeRecordingUseCase
    {
        IReadOnlyList<DailyTimeRecordDto> ListDailyRecord();
    }
}
