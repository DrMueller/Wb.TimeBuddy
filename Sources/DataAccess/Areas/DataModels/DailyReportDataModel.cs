using System;
using System.Collections.Generic;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;

namespace Mmu.Wb.TimeBuddy.DataAccess.Areas.DataModels
{
    internal class DailyReportDataModel : AggregateRootDataModel<string>
    {
        public DateTime Date { get; set; }
        public List<ReportEntryDataModel> ReportEntries { get; set; }
    }
}