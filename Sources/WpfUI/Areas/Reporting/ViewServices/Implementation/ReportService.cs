using System;
using System.Diagnostics;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.Wb.TimeBuddy.Domain.Areas.Factories;
using Mmu.Wb.TimeBuddy.Domain.Areas.Repositories;

namespace Mmu.Wb.TimeBuddy.WpfUI.Areas.Reporting.ViewServices.Implementation
{
    public class ReportService : IReportService
    {
        private readonly IDailyReportRepository _dailyReportRepo;
        private readonly IDayExportFactory _dayExportFactory;
        private readonly IFileSystem _fileSystem;

        public ReportService(
            IFileSystem fileSystem,
            IDailyReportRepository dailyReportRepo,
            IDayExportFactory dayExportFactory)
        {
            _fileSystem = fileSystem;
            _dailyReportRepo = dailyReportRepo;
            _dayExportFactory = dayExportFactory;
        }

        public async Task CreateReportAsync()
        {
            var entries = await _dailyReportRepo.LoadSinceAsync(DateTime.Now.Date.AddDays(-14));

            var dailyReports = entries
                .OrderBy(f => f.Date)
                .ToList();

            var dayExports = dailyReports.Select(dr => _dayExportFactory.Create(dr)).ToList();
            var sb = new StringBuilder();

            foreach (var de in dayExports)
            {
                foreach (var dayExportEntry in de.Entries)
                {
                    if (dayExportEntry.DescriptionExternal != "Scout24")
                    {
                        continue;
                    }

                    sb.Append(dayExportEntry.DescriptionExternal);
                    sb.Append("\t");
                    sb.Append(de.DateToExport.ToShortDateString());
                    sb.Append("\t");
                    sb.AppendLine(dayExportEntry.TimeDescription.RoundedAbsoluteTimeDescription);
                }
            }

            var tempFileName = _fileSystem.Path.GetTempFileName();
            _fileSystem.File.WriteAllText(tempFileName, sb.ToString());
            Process.Start("notepad.exe", tempFileName);
        }
    }
}