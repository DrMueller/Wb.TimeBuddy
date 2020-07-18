namespace Mmu.Wb.TimeBuddy.Domain.Areas.Models.Export
{
    public class DayExportEntriesOverview
    {
        public TimeDescription TimeDescription { get; }

        public DayExportEntriesOverview(TimeDescription timeDescription)
        {
            TimeDescription = timeDescription;
        }
    }
}