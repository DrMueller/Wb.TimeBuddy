using Mmu.Wb.TimeBuddy.Domain.Areas.Models.Export;

namespace Mmu.Wb.TimeBuddy.WpfUI.Areas.Details.ViewServices.Servants
{
    public interface IFileWriter
    {
        void WriteAndOpenTextFile(DayExport dayExport);
    }
}