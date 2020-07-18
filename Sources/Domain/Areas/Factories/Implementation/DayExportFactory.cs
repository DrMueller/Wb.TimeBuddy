using System;
using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Wb.TimeBuddy.Domain.Areas.Models.Export;
using Mmu.Wb.TimeBuddy.Domain.Areas.Models.Management;

namespace Mmu.Wb.TimeBuddy.Domain.Areas.Factories.Implementation
{
    internal class DayExportFactory : IDayExportFactory
    {
        public DayExport Create(DailyReport report)
        {
            var exportEntries = CalculateExportEntries(report);
            var overviewEntry = CreateOverview(report);

            return new DayExport(
                overviewEntry,
                report.Date,
                exportEntries);
        }

        private static IReadOnlyCollection<DayExportReportEntry> CalculateExportEntries(DailyReport report)
        {
            var grpd = report.SortedReportEntries.GroupBy(f => f.WorkDescription);
            var entries = grpd.Select(CreateFromReportEntries).ToList();
            return entries;
        }

        private static DayExportReportEntry CreateFromReportEntries(IGrouping<string, ReportEntry> entries)
        {
            var reportedTimeSpans = default(TimeSpan);
            entries.ForEach(f => reportedTimeSpans += f.CalculateReportedMinutes());

            var timeDescription = new TimeDescription(reportedTimeSpans);

            return new DayExportReportEntry(timeDescription, entries.Key);
        }

        private static DayExportEntriesOverview CreateOverview(DailyReport report)
        {
            var timeSpan = default(TimeSpan);
            report.SortedReportEntries.ForEach(entry => timeSpan += entry.CalculateReportedMinutes());

            var timeDescription = new TimeDescription(timeSpan);

            return new DayExportEntriesOverview(timeDescription);
        }
    }
}