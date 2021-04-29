using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Wb.TimeBuddy.WpfUI.Areas.Reporting.Views.Report
{
    public class ReportViewModel : ViewModelBase, IInitializableViewModel, INavigatableViewModel
    {
        private readonly CommandContainer _commandContainer;

        public CommandsViewData Commands => _commandContainer.CommandsViewData;

        public ReportViewModel(CommandContainer commandContainer)
        {
            _commandContainer = commandContainer;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            await _commandContainer.InitializeAsync(this);
        }

        public string HeadingDescription { get; } = "Reporting";
        public string NavigationDescription { get; } = "Reporting";
        public int NavigationSequence { get; } = 2;
    }
}
