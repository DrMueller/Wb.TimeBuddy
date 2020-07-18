using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Wb.TimeBuddy.Domain.Areas.Models.Export
{
    public class DayExportReportEntry
    {
        public string DescriptionExternal { get; }
        public TimeDescription TimeDescription { get; }

        public DayExportReportEntry(
            TimeDescription timeDescription,
            string descriptionExternal)
        {
            Guard.ObjectNotNull(() => timeDescription);

            TimeDescription = timeDescription;
            DescriptionExternal = string.IsNullOrEmpty(descriptionExternal) ? "No description" : descriptionExternal;
        }
    }
}