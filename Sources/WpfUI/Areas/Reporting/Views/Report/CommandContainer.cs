using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Wb.TimeBuddy.WpfUI.Areas.Reporting.ViewServices;

namespace Mmu.Wb.TimeBuddy.WpfUI.Areas.Reporting.Views.Report
{
    public class CommandContainer : IViewModelCommandContainer<ReportViewModel>
    {
        private readonly IReportService _reportService;
        private ReportViewModel _context;

        public CommandContainer(IReportService reportService)
        {
            _reportService = reportService;
        }

        public CommandsViewData CommandsViewData { get; private set; }

        private IViewModelCommand CreateReport =>
            new ViewModelCommand(
                "Report",
                new AsyncRelayCommand(
                    async () =>
                    {
                        await _reportService.CreateReportAsync();
                    }));

        public Task InitializeAsync(ReportViewModel context)
        {
            _context = context;

            CommandsViewData = new CommandsViewData(
                CreateReport);

            return Task.CompletedTask;
        }
    }
}