using Mmu.Wb.TimeBuddy.Domain.Areas.Models.Export;
using Mmu.Wb.TimeBuddy.Domain.Areas.Models.Management;

namespace Mmu.Wb.TimeBuddy.Domain.Areas.Factories
{
    public interface IDayExportFactory
    {
        DayExport Create(DailyReport report);
    }
}