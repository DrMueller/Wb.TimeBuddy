using System;
using Mmu.Wb.TimeBuddy.Domain.Areas.Models.Management;

namespace Mmu.Wb.TimeBuddy.Domain.Areas.Factories
{
    public interface IDailyReportFactory
    {
        DailyReport Create(DateTime reportDate);
    }
}