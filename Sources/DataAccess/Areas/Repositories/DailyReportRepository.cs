using System;
using System.Threading.Tasks;
using Mmu.Mlh.DataAccess.Areas.DatabaseAccess;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services;
using Mmu.Mlh.DataAccess.Areas.Repositories;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Wb.TimeBuddy.DataAccess.Areas.DataModels;
using Mmu.Wb.TimeBuddy.Domain.Areas.Models.Management;
using Mmu.Wb.TimeBuddy.Domain.Areas.Repositories;

namespace Mmu.Wb.TimeBuddy.DataAccess.Areas.Repositories
{
    internal class DailyReportRepository : RepositoryBase<DailyReport, DailyReportDataModel, string>, IDailyReportRepository
    {
        private readonly IDataModelAdapter<DailyReportDataModel, DailyReport, string> _dataModelAdapter;
        private readonly IDataModelRepository<DailyReportDataModel, string> _dataModelRepository;

        public DailyReportRepository(
            IDataModelRepository<DailyReportDataModel, string> dataModelRepository,
            IDataModelAdapter<DailyReportDataModel, DailyReport, string> dataModelAdapter) : base(dataModelRepository, dataModelAdapter)
        {
            _dataModelRepository = dataModelRepository;
            _dataModelAdapter = dataModelAdapter;
        }

        public async Task<Maybe<DailyReport>> LoadByDateAsync(DateTime date)
        {
            var dataModel = await _dataModelRepository.LoadSingleAsync(f => f.Date.Date == date.Date);
            if (dataModel == null)
            {
                return Maybe.CreateNone<DailyReport>();
            }

            var result = _dataModelAdapter.Adapt(dataModel);
            return result;
        }
    }
}