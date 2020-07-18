using System;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.Wb.TimeBuddy.Domain.Areas.Models.Management
{
    public class ReportEntry : Entity<string>
    {
        public TimeStamp BeginTime { get; private set; }
        public Maybe<TimeStamp> EndTime { get; private set; }
        public string WorkDescription { get; private set; }

        internal bool HasTimesSet
        {
            get
            {
                return EndTime.Evaluate(ts => true, () => false);
            }
        }

        public ReportEntry(
            TimeStamp beginTime,
            Maybe<TimeStamp> endTime,
            string workDescription,
            string id) : base(id)
        {
            BeginTime = beginTime;
            EndTime = endTime;
            WorkDescription = workDescription;
        }

        internal void AlignValues(ReportEntry newEntry)
        {
            BeginTime = newEntry.BeginTime;
            EndTime = newEntry.EndTime;
            WorkDescription = newEntry.WorkDescription;
        }

        internal TimeSpan CalculateReportedMinutes()
        {
            return EndTime.Evaluate(to => to.ToTimeSpan() - BeginTime.ToTimeSpan(), () => default);
        }
    }
}