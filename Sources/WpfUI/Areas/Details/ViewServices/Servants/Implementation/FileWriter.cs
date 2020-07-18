using System.Diagnostics;
using System.IO.Abstractions;
using System.Text;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Wb.TimeBuddy.Domain.Areas.Models.Export;

namespace Mmu.Wb.TimeBuddy.WpfUI.Areas.Details.ViewServices.Servants.Implementation
{
    public class FileWriter : IFileWriter
    {
        private readonly IFileSystem _fileSystem;

        public FileWriter(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public void WriteAndOpenTextFile(DayExport dayExport)
        {
            var sb = new StringBuilder();

            sb.Append("Export vom: ");
            sb.AppendLine(dayExport.DateToExport.ToString("dddd, dd.MM.yyyy"));
            sb.AppendLine();

            dayExport.Entries.ForEach(
                f =>
                {
                    sb.Append(f.TimeDescription.RoundedAbsoluteTimeDescription);
                    sb.Append("\t");

                    // sb.Append(f.TimeDescription.TimeDescriptionInMinutes);
                    // sb.Append("\t");
                    sb.AppendLine(f.DescriptionExternal);
                });

            sb.Append(dayExport.Overview.TimeDescription.RoundedAbsoluteTimeDescription);
            sb.Append("\t");

            // sb.Append(dayExport.Overview.TimeDescription.TimeDescriptionInMinutes);
            // sb.Append("\t");
            var tempFileName = _fileSystem.Path.GetTempFileName();
            _fileSystem.File.WriteAllText(tempFileName, sb.ToString());
            Process.Start("notepad.exe", tempFileName);
        }
    }
}