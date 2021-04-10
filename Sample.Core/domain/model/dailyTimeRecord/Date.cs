using Sample.Core.domain.shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Core.domain.model.dailyTimeRecord
{
    internal class Date : ValueObject<Date>
    {
        public DateTime DateTime { get; }

        public Date(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                throw new ArgumentException("Date クラスのコンストラクタに DateTime.MinValueが渡されました。西暦0001年はあり得ません。", "date");
            }
            this.DateTime = date;
        }

        public override bool SameValueAs(Date other)
        {
            return this.DateTime.Date == other.DateTime.Date;
        }
    }
}
