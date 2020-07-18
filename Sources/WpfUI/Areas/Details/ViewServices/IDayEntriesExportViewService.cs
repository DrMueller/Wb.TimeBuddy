using Mmu.Wb.TimeBuddy.Domain.Areas.Models.Management;

namespace Mmu.Wb.TimeBuddy.WpfUI.Areas.Details.ViewServices
{
    public interface IDayEntriesExportViewService
    {
        void ExportToFile(DailyReport report);
    }
}