using System.Threading.Tasks;
using Mmu.Wb.TimeBuddy.Domain.Areas.Models.Management;

namespace Mmu.Wb.TimeBuddy.WpfUI.Areas.Details.ViewServices
{
    public interface IDayDetailsViewService
    {
        Task<DailyReport> LoadDailyReportAsync(params object[] initParams);
    }
}