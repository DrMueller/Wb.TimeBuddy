using AutoMapper;
using Mmu.Wb.TimeBuddy.DataAccess.Areas.DataModels;
using Mmu.Wb.TimeBuddy.Domain.Areas.Models.Management;

namespace Mmu.Wb.TimeBuddy.DataAccess.Areas.DataModelRepositories.Adapters.Implementation.Profiles
{
    public class ReportEntryDataModelProfile : Profile
    {
        public ReportEntryDataModelProfile()
        {
            CreateMap<ReportEntry, ReportEntryDataModel>()
                .ForMember(d => d.BeginTime, c => c.MapFrom(f => f.BeginTime))
                .ForMember(d => d.EndTime, c => c.MapFrom(f => f.EndTime))
                .ForMember(d => d.Id, c => c.MapFrom(f => f.Id))
                .ForMember(d => d.WorkDescription, c => c.MapFrom(f => f.WorkDescription));
        }
    }
}