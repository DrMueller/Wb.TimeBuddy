using AutoMapper;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes.Implementation;
using Mmu.Wb.TimeBuddy.DataAccess.Areas.DataModels;
using Mmu.Wb.TimeBuddy.Domain.Areas.Models.Management;

namespace Mmu.Wb.TimeBuddy.DataAccess.Areas.DataModelRepositories.Adapters.Implementation.Profiles
{
    public class TimeStampDataModelProfile : Profile
    {
        public TimeStampDataModelProfile()
        {
            CreateMap<TimeStamp, TimeStampDataModel>()
                .ForMember(d => d.Hour, c => c.MapFrom(f => f.Hour))
                .ForMember(d => d.Minute, c => c.MapFrom(f => f.Minute));

            CreateMap<Some<TimeStamp>, TimeStampDataModel>()
                .ForMember(d => d.Hour, c => c.MapFrom(f => f.Reduce(() => null).Hour))
                .ForMember(d => d.Minute, c => c.MapFrom(f => f.Reduce(() => null).Minute));

            CreateMap<None<TimeStamp>, TimeStampDataModel>()
                .ForMember(d => d.Hour, c => c.MapFrom(f => string.Empty))
                .ForMember(d => d.Minute, c => c.MapFrom(f => string.Empty));
        }
    }
}