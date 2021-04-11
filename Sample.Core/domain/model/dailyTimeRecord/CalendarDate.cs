using Sample.Core.domain.shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.domain.model.dailyTimeRecord
{
    internal class CalendarDate : ValueObject<CalendarDate>
    {
        public DateTime DateTime { get; }

        public CalendarDate(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                throw new ArgumentException("Date クラスのコンストラクタに DateTime.MinValueが渡されました。西暦0001年はあり得ません。", "date");
            }

            this.DateTime = new DateTime(date.Year, date.Month, date.Day);
        }

        public override bool SameValueAs(CalendarDate other)
        {
            return this.DateTime.Date == other.DateTime.Date;
        }
    }
}
