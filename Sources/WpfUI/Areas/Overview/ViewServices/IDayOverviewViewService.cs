using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Wb.TimeBuddy.WpfUI.Areas.Overview.ViewData;

namespace Mmu.Wb.TimeBuddy.WpfUI.Areas.Overview.ViewServices
{
    public interface IDayOverviewViewService
    {
        Task<IReadOnlyCollection<DayOverviewViewData>> LoadAllAsync();
    }
}