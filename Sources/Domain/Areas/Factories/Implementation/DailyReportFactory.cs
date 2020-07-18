using System;
using System.Collections.Generic;
using Mmu.Wb.TimeBuddy.Domain.Areas.Models.Management;

namespace Mmu.Wb.TimeBuddy.Domain.Areas.Factories.Implementation
{
    internal class DailyReportFactory : IDailyReportFactory
    {
        public DailyReport Create(DateTime reportDate)
        {
            var guid = Guid.NewGuid().ToString();
            return new DailyReport(reportDate, new List<ReportEntry>(), guid);
        }
    }
}