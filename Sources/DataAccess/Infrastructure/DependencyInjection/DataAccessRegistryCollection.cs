using Lamar;
using Mmu.Wb.TimeBuddy.DataAccess.Areas.DataModelRepositories;
using Mmu.Wb.TimeBuddy.DataAccess.Areas.DataModelRepositories.Adapters;
using Mmu.Wb.TimeBuddy.DataAccess.Areas.DataModelRepositories.Adapters.Implementation;
using Mmu.Wb.TimeBuddy.DataAccess.Areas.DataModelRepositories.Implementation;
using Mmu.Wb.TimeBuddy.DataAccess.Areas.Repositories;
using Mmu.Wb.TimeBuddy.Domain.Areas.Repositories;

namespace Mmu.Wb.TimeBuddy.DataAccess.Infrastructure.DependencyInjection
{
    public class DataAccessRegistryCollection : ServiceRegistry
    {
        public DataAccessRegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<DataAccessRegistryCollection>();
                    scanner.WithDefaultConventions();
                });

            For<IDailyReportDataModelAdapter>().Use<DailyReportDataModelAdapter>().Singleton();
            For<IDailyReportDataModelRepository>().Use<DailyReportDataModelRepository>().Singleton();
            For<IDailyReportRepository>().Use<DailyReportRepository>().Singleton();
        }
    }
}