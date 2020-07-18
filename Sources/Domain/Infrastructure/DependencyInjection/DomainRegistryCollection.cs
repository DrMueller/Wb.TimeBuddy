using Lamar;
using Mmu.Wb.TimeBuddy.Domain.Areas.Factories;
using Mmu.Wb.TimeBuddy.Domain.Areas.Factories.Implementation;

namespace Mmu.Wb.TimeBuddy.Domain.Infrastructure.DependencyInjection
{
    public class DomainRegistryCollection : ServiceRegistry
    {
        public DomainRegistryCollection()
        {
            For<IDailyReportFactory>().Use<DailyReportFactory>().Singleton();
            For<IReportEntryFactory>().Use<ReportEntryFactory>().Singleton();
            For<IDayExportFactory>().Use<DayExportFactory>().Singleton();
        }
    }
}