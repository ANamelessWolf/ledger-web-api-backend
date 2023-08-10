using AutoMapper;
using Nameless.Ledger.Models;
using Nameless.Ledger.ModelsDto;
using Nameless.Ledger.ModelTypes;
using static Nameless.Ledger.Utils.FormatterUtils;
namespace Nameless.WebApi.Mapper
{
    public class HelperMapper : Profile
    {
        public HelperMapper()
        {
            #region Mapper Test
            CreateMap<FinancingEntity, FinancingEntityDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FinancingType, opt => opt.MapFrom(src => src.FinancingType.GetHeader()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => Clean(src.Name)))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => Clean(src.Description)));
            CreateMap<FinancingEntityDto, FinancingEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FinancingType, opt => opt.MapFrom(src => MapFinancingEntityType(src.FinancingType)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            CreateMap<NewFinancingEntityDto, FinancingEntity> ()
                .ForMember(dest => dest.FinancingType, opt => opt.MapFrom(src => (FinancingEntityType)src.FinancingType))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            #endregion
        }

        private object Clean(string? value)
        {
            if (value == null)
                return "";
            return value.Trim();
        }


        private FinancingEntityType MapFinancingEntityType(string? value) =>
            value != null ? value.GetFinancingEntityType() : FinancingEntityType.NOT_ESPECIFIED;

    }
}
