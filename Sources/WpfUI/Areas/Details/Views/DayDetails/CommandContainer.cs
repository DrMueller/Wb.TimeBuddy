using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Mlh.LanguageExtensions.Areas.DeepCopying;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Wb.TimeBuddy.Domain.Areas.Factories;
using Mmu.Wb.TimeBuddy.Domain.Areas.Models.Management;
using Mmu.Wb.TimeBuddy.Domain.Areas.Repositories;
using Mmu.Wb.TimeBuddy.WpfUI.Areas.Details.ViewData;
using Mmu.Wb.TimeBuddy.WpfUI.Areas.Details.ViewServices;

namespace Mmu.Wb.TimeBuddy.WpfUI.Areas.Details.Views.DayDetails
{
    public class CommandContainer : IViewModelCommandContainer<EditDayViewModel>
    {
        private readonly IDailyReportRepository _dailyReportRepository;
        private readonly IInformationPublisher _informationPublisher;
        private readonly IReportEntryFactory _reportEntryFactory;
        private readonly IDayEntriesExportViewService _sapExportService;
        private readonly IViewModelDisplayService _vmDisplayService;
        private EditDayViewModel _context;

        public ICommand Clear
        {
            get
            {
                return new RelayCommand(
                    async () =>
                    {
                        await _context.ClearSelectionAsync();
                    });
            }
        }

        public ICommand CopyText
        {
            get
            {
                return new ParametredRelayCommand(
                    obj =>
                    {
                        var reportEntry = (ReportEntryViewData)obj;
                        _context.SelectedReportEntry.WorkDescription = reportEntry.WorkDescription;
                    });
            }
        }

        public ICommand DeleteEntry
        {
            get
            {
                return new ParametredRelayCommand(
                    async obj =>
                    {
                        var reportEntry = (ReportEntryViewData)obj;
                        _context.DailyReport.RemoveReportEntry(reportEntry.ReportEntryId);
                        await _dailyReportRepository.SaveAsync(_context.DailyReport);
                        _informationPublisher.Publish(InformationEntry.CreateSuccess("Deleted", false, 5));
                        await _context.RefreshReportEntriesAsync();
                    });
            }
        }

        public ICommand EditEntry
        {
            get
            {
                return new ParametredRelayCommand(
                    obj =>
                    {
                        var reportEntry = (ReportEntryViewData)obj;
                        _context.SelectedReportEntry = reportEntry.DeepCopy();
                    });
            }
        }

        public ICommand ExportToFile
        {
            get
            {
                return new RelayCommand(
                    () =>
                    {
                        _sapExportService.ExportToFile(_context.DailyReport);
                    });
            }
        }

        public ICommand NavigateToNextDay
        {
            get
            {
                return new RelayCommand(
                    () =>
                    {
                        NavigateToDayDetails(1);
                    });
            }
        }

        public ICommand NavigateToPreviousDay
        {
            get
            {
                return new RelayCommand(
                    () =>
                    {
                        NavigateToDayDetails(-1);
                    });
            }
        }

        public ICommand Save
        {
            get
            {
                return new RelayCommand(
                    async () =>
                    {
                        var entry = _context.SelectedReportEntry;
                        var reportEntry = _reportEntryFactory.Create(
                            TimeStamp.Parse(entry.BeginTime),
                            TimeStamp.TryParsing(entry.EndTime),
                            entry.WorkDescription,
                            entry.ReportEntryId);

                        var upsertResult = _context.DailyReport.UpsertReportEntry(reportEntry);
                        if (upsertResult.IsSuccess)
                        {
                            await _dailyReportRepository.SaveAsync(_context.DailyReport);
                            await _context.RefreshReportEntriesAsync();
                            _informationPublisher.Publish(InformationEntry.CreateSuccess("Saved", false, 5));
                        }
                        else
                        {
                            _informationPublisher.Publish(InformationEntry.CreateInfo(upsertResult.ErrorMessage, false, 5));
                        }
                    },
                    () => !_context.SelectedReportEntry.HasErrors);
            }
        }

        public CommandContainer(
            IDayEntriesExportViewService sapExportService,
            IReportEntryFactory reportEntryFactory,
            IDailyReportRepository dailyReportRepository,
            IInformationPublisher informationPublisher,
            IViewModelDisplayService vmDisplayService)
        {
            _sapExportService = sapExportService;
            _reportEntryFactory = reportEntryFactory;
            _dailyReportRepository = dailyReportRepository;
            _informationPublisher = informationPublisher;
            _vmDisplayService = vmDisplayService;
        }

        public Task InitializeAsync(EditDayViewModel context)
        {
            _context = context;
            return Task.CompletedTask;
        }

        private void NavigateToDayDetails(int dayOffset)
        {
            var tomorrow = _context.DailyReport.Date.AddDays(dayOffset);
            _vmDisplayService.DisplayAsync<EditDayViewModel>(tomorrow);
        }
    }
}