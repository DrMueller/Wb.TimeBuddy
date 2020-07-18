using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Wb.TimeBuddy.Domain.Areas.Models.Management;

namespace Mmu.Wb.TimeBuddy.Domain.Areas.Factories
{
    public interface IReportEntryFactory
    {
        ReportEntry Create(TimeStamp beginTime, Maybe<TimeStamp> endTime, string workDescription, string id);
    }
}