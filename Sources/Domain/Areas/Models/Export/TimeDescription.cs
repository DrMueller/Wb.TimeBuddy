using System;
using System.Globalization;

namespace Mmu.Wb.TimeBuddy.Domain.Areas.Models.Export
{
    public class TimeDescription
    {
        private readonly TimeSpan _timeSpan;

        public string RoundedAbsoluteTimeDescription
        {
            get
            {
                var roundedTime = Math.Round(_timeSpan.TotalHours, 2);
                var surplusMinutes = Math.Round(roundedTime % 0.25, 2);

                if (Math.Abs(surplusMinutes) > 0)
                {
                    roundedTime -= surplusMinutes;
                    roundedTime += 0.25;
                }

                var absoluteTime = roundedTime.ToString(CultureInfo.InvariantCulture);

                return absoluteTime;
            }
        }

        public string TimeDescriptionInMinutes => _timeSpan.ToString(@"hh\:mm");

        public TimeDescription(TimeSpan timeSpan)
        {
            _timeSpan = timeSpan;
        }
    }
}