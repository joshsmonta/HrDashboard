using AutoMapper;
using HrDashboard.Models;
using HrDashboard.DTOs;

namespace HrDashboard.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //DomainModel to Dto
            CreateMap<AlphaList, AlphaListDto>();
            CreateMap<BetaList, BetaListDto>();
            CreateMap<Position, PositionDto>();
            CreateMap<Division, DivisionDto>();
            CreateMap<Section, SectionDto>();
            CreateMap<Logbook, LogbookDto>();
            CreateMap<BusinessUnit, BusinessUnitDto>();

            //Dto to DomainModel
            CreateMap<AlphaListDto, AlphaList>().ForMember(m => m.Id, opt => opt.Ignore());
            CreateMap<BetaListDto, BetaList>().ForMember(m => m.Id, opt => opt.Ignore());
            CreateMap<PositionDto, Position>().ForMember(m => m.PosId, opt => opt.Ignore());
            CreateMap<DivisionDto, Division>().ForMember(m => m.DivId, opt => opt.Ignore());
            CreateMap<SectionDto, Section>().ForMember(m => m.SectId, opt => opt.Ignore());
            CreateMap<LogbookDto, Logbook>().ForMember(m => m.LogId, opt => opt.Ignore());
            CreateMap<BusinessUnitDto, BusinessUnit>().ForMember(m => m.unitId, opt => opt.Ignore());
        }
    }
}