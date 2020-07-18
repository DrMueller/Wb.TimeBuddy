using System.Linq;
using AutoMapper;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Services.Implementation;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Wb.TimeBuddy.DataAccess.Areas.DataModels;
using Mmu.Wb.TimeBuddy.Domain.Areas.Factories;
using Mmu.Wb.TimeBuddy.Domain.Areas.Models.Management;

namespace Mmu.Wb.TimeBuddy.DataAccess.Areas.DataModelRepositories.Adapters.Implementation
{
    internal class DailyReportDataModelAdapter : DataModelAdapterBase<DailyReportDataModel, DailyReport, string>, IDailyReportDataModelAdapter
    {
        private readonly IMapper _mapper;
        private readonly IReportEntryFactory _reportEntryFactory;

        public DailyReportDataModelAdapter(
            IReportEntryFactory reportEntryFactory,
            IMapper mapper) : base(mapper)
        {
            _reportEntryFactory = reportEntryFactory;
            _mapper = mapper;
        }

        public override DailyReport Adapt(DailyReportDataModel dataModel)
        {
            var reportEntries = dataModel.ReportEntries.Select(AdaptReportEntry).ToList();
            return new DailyReport(dataModel.Date, reportEntries, dataModel.Id);
        }

        public override DailyReportDataModel Adapt(DailyReport aggregateRoot)
        {
            var dataModel = _mapper.Map<DailyReportDataModel>(aggregateRoot);

            return dataModel;
        }

        private ReportEntry AdaptReportEntry(ReportEntryDataModel dataModel)
        {
            var beginTime = new TimeStamp(dataModel.BeginTime.Hour, dataModel.BeginTime.Minute);
            Maybe<TimeStamp> endTime;

            if (string.IsNullOrEmpty(dataModel.EndTime.Hour))
            {
                endTime = Maybe.CreateNone<TimeStamp>();
            }
            else
            {
                endTime = new TimeStamp(dataModel.EndTime.Hour, dataModel.EndTime.Minute);
            }

            var result = _reportEntryFactory.Create(beginTime, endTime, dataModel.WorkDescription, dataModel.Id);
            return result;
        }
    }
}