using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sample.WebMVC.Command
{
    public class DailyTimeRecordEditCommand : IValidatableObject
    {
        public string Id { get; set; }

        public DateTime Date { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public int GetStartTimeHour()
        {
            return int.Parse(this.StartTime.Split(':')[0]);
        }

        public int GetStartTimeMinute()
        {
            return int.Parse(this.StartTime.Split(':')[1]);
        }

        public int GetEndTimeHour()
        {
            return int.Parse(this.EndTime.Split(':')[0]);
        }

        public int GetEndTimeMinute()
        {
            return int.Parse(this.EndTime.Split(':')[1]);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!new TimeValidator(this.StartTime).IsFormatValid())
                yield return new ValidationResult("StartTime Invalid", new string[] { "StartTime" });

            if (!new TimeValidator(this.EndTime).IsFormatValid())
                yield return new ValidationResult("EndTime Invalid", new string[] { "EndTime" });


            yield return ValidationResult.Success;
        }

        class TimeValidator
        {
            private string InputTime { get; }

            public TimeValidator(string inputTime)
            {
                this.InputTime = inputTime;
            }

            public bool IsFormatValid()
            {
                return Regex.IsMatch(this.InputTime, "^([01]?[0-9]|2[0-3]):[0-5][0-9]$");
            }
        }

    }
}
