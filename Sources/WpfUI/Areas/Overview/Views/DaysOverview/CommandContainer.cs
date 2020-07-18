using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Wb.TimeBuddy.WpfUI.Areas.Details.Views.DayDetails;
using Mmu.Wb.TimeBuddy.WpfUI.Areas.Overview.ViewData;

namespace Mmu.Wb.TimeBuddy.WpfUI.Areas.Overview.Views.DaysOverview
{
    public class CommandContainer : IViewModelCommandContainer<DaysOverviewViewModel>
    {
        private readonly IViewModelDisplayService _displayService;

        public ICommand EditDay
        {
            get
            {
                return new ParametredRelayCommand(
                    obj =>
                    {
                        var overviewEntry = (DayOverviewViewData)obj;
                        _displayService.DisplayAsync<EditDayViewModel>(overviewEntry.Date);
                    });
            }
        }

        public CommandContainer(IViewModelDisplayService displayService)
        {
            _displayService = displayService;
        }

        public Task InitializeAsync(DaysOverviewViewModel context)
        {
            return Task.CompletedTask;
        }
    }
}