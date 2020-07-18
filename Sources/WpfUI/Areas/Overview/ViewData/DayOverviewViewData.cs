using System;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Wb.TimeBuddy.WpfUI.Areas.Overview.ViewData
{
    public class DayOverviewViewData
    {
        public string DailyReportId { get; }
        public DateTime Date { get; }
        public string DateDescription => Date.ToShortDateString();
        public string ReportedTimeDescription { get; }

        public DayOverviewViewData(
            DateTime date,
            string reportedTimeDescription,
            string dailyReportId)
        {
            Guard.StringNotNullOrEmpty(() => reportedTimeDescription);
            Guard.StringNotNullOrEmpty(() => dailyReportId);

            Date = date;
            ReportedTimeDescription = reportedTimeDescription;
            DailyReportId = dailyReportId;
        }
    }
}