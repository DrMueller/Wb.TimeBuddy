using Mmu.Mlh.DataAccess.FileSystem.Areas.DataModelRepositories.Services.Implementation;
using Mmu.Mlh.DataAccess.FileSystem.Areas.DataModelRepositories.Services.Servants;
using Mmu.Wb.TimeBuddy.DataAccess.Areas.DataModels;

namespace Mmu.Wb.TimeBuddy.DataAccess.Areas.DataModelRepositories.Implementation
{
    internal class DailyReportDataModelRepository : FileSystemDataModelRepository<DailyReportDataModel>, IDailyReportDataModelRepository
    {
        public DailyReportDataModelRepository(
            IFileSystemProxy<DailyReportDataModel> fileSystemProxy,
            IDataModelFileAdapter<DailyReportDataModel> fileAdapter)
            : base(fileSystemProxy, fileAdapter)
        {
        }
    }
}