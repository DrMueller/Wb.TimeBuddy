using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;
using Mmu.Wb.TimeBuddy.DataAccess.Areas.DataModels;
using Mmu.Wb.TimeBuddy.Domain.Areas.Models.Management;

namespace Mmu.Wb.TimeBuddy.DataAccess.Areas.DataModelRepositories.Adapters
{
    internal interface IDailyReportDataModelAdapter : IDataModelAdapter<DailyReportDataModel, DailyReport, string>
    {
    }
}