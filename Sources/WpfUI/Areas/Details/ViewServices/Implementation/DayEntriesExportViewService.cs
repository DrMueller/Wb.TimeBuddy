using Mmu.Wb.TimeBuddy.Domain.Areas.Factories;
using Mmu.Wb.TimeBuddy.Domain.Areas.Models.Management;
using Mmu.Wb.TimeBuddy.WpfUI.Areas.Details.ViewServices.Servants;

namespace Mmu.Wb.TimeBuddy.WpfUI.Areas.Details.ViewServices.Implementation
{
    public class DayEntriesExportViewService : IDayEntriesExportViewService
    {
        private readonly IDayExportFactory _dayExportFactory;
        private readonly IFileWriter _fileWriter;

        public DayEntriesExportViewService(
            IDayExportFactory dayExportFactory,
            IFileWriter fileWriter)
        {
            _dayExportFactory = dayExportFactory;
            _fileWriter = fileWriter;
        }

        public void ExportToFile(DailyReport report)
        {
            var dayExport = _dayExportFactory.Create(report);
            _fileWriter.WriteAndOpenTextFile(dayExport);
        }
    }
}