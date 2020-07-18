using System;
using System.Threading.Tasks;
using Mmu.Mlh.DomainExtensions.Areas.Repositories;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Wb.TimeBuddy.Domain.Areas.Models.Management;

namespace Mmu.Wb.TimeBuddy.Domain.Areas.Repositories
{
    public interface IDailyReportRepository : IRepository<DailyReport, string>
    {
        Task<Maybe<DailyReport>> LoadByDateAsync(DateTime reportData);
    }
}