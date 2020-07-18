using System;
using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Wb.TimeBuddy.Domain.Areas.Models.Export
{
    public class DayExport
    {
        public DateTime DateToExport { get; }
        public IReadOnlyCollection<DayExportReportEntry> Entries { get; }
        public DayExportEntriesOverview Overview { get; }

        public DayExport(
            DayExportEntriesOverview overview,
            DateTime dateToExport,
            IReadOnlyCollection<DayExportReportEntry> entries)
        {
            Guard.ObjectNotNull(() => overview);
            Guard.ObjectNotNull(() => entries);

            Overview = overview;
            DateToExport = dateToExport;
            Entries = entries;
        }
    }
}