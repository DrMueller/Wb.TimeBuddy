using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Wb.TimeBuddy.WpfUI.Areas.Overview.ViewData;
using Mmu.Wb.TimeBuddy.WpfUI.Areas.Overview.ViewServices;

namespace Mmu.Wb.TimeBuddy.WpfUI.Areas.Overview.Views.DaysOverview
{
    public class DaysOverviewViewModel : ViewModelBase, IInitializableViewModel, INavigatableViewModel
    {
        private readonly IDayOverviewViewService _dayOverviewViewService;
        private IReadOnlyCollection<DayOverviewViewData> _overviewEntries;
        public CommandContainer CommandContainer { get; }
        public string HeadingDescription { get; } = "Overview";
        public string NavigationDescription { get; } = "Overview";
        public int NavigationSequence { get; } = 1;

        public IReadOnlyCollection<DayOverviewViewData> OverviewEntries
        {
            get => _overviewEntries;
            set
            {
                if (!Equals(_overviewEntries, value))
                {
                    _overviewEntries = value;
                    OnPropertyChanged();
                }
            }
        }

        public DaysOverviewViewModel(
            IDayOverviewViewService dayOverviewViewService,
            CommandContainer commandContainer)
        {
            _dayOverviewViewService = dayOverviewViewService;
            CommandContainer = commandContainer;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            OverviewEntries = await _dayOverviewViewService.LoadAllAsync();
            await CommandContainer.InitializeAsync(this);
        }
    }
}