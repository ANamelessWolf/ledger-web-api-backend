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
            CreateMap<FinancingEntity, FinancingEntityDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FinancingType, opt => opt.MapFrom(src => src.FinancingType.GetHeader()))
                .ForMember(dest => dest.FinancingTypeId, opt => opt.MapFrom(src => src.FinancingType))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => Clean(src.Name)))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => Clean(src.Description)));
            CreateMap<FinancingEntityDto, FinancingEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FinancingType, opt => opt.MapFrom(src => MapFinancingEntityType(src.FinancingType)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            CreateMap<NewFinancingEntityDto, FinancingEntity>()
                .ForMember(dest => dest.FinancingType, opt => opt.MapFrom(src => (FinancingEntityType)src.FinancingType))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<CreditCard, CreditCardDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.FinancingEntityId, opt => opt.MapFrom(src => src.FinancingEntityId))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.ShortName))
               .ForMember(dest => dest.Credit, opt => opt.MapFrom(src => Money(src.Credit)))
               .ForMember(dest => dest.UsedCredit, opt => opt.MapFrom(src => Money(src.UsedCredit)))
               .ForMember(dest => dest.CreditValue, opt => opt.MapFrom(src => src.Credit))
               .ForMember(dest => dest.UsedCreditValue, opt => opt.MapFrom(src => src.UsedCredit))
               .ForMember(dest => dest.ClosingDay, opt => opt.MapFrom(src => src.ClosingDay))
               .ForMember(dest => dest.DueDay, opt => opt.MapFrom(src => src.DueDay))
               .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => src.ExpirationDate))
               .ForMember(dest => dest.CardType, opt => opt.MapFrom(src => src.CardType.GetHeader()))
               .ForMember(dest => dest.CardTypeId, opt => opt.MapFrom(src => src.CardType))
               .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
               .ForMember(dest => dest.EndingCardNumber, opt => opt.MapFrom(src => src.EndingCardNumber));

            CreateMap<CreditCardDto, CreditCard>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FinancingEntityId, opt => opt.MapFrom(src => src.FinancingEntityId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.ShortName))
                //.ForMember(dest => dest.CreditValue, opt => opt.MapFrom(src => Money(src.Credit)))
                //.ForMember(dest => dest.UsedCreditValue, opt => opt.MapFrom(src => Money(src.UsedCredit)))
                .ForMember(dest => dest.Credit, opt => opt.MapFrom(src => src.Credit))
                .ForMember(dest => dest.UsedCredit, opt => opt.MapFrom(src => src.UsedCredit))
                .ForMember(dest => dest.ClosingDay, opt => opt.MapFrom(src => src.ClosingDay))
                .ForMember(dest => dest.DueDay, opt => opt.MapFrom(src => src.DueDay))
                .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => src.ExpirationDate))
                .ForMember(dest => dest.CardType, opt => opt.MapFrom(src => src.CardType))
                //.ForMember(dest => dest.CardTypeId, opt => opt.MapFrom(src => src.CardType))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.EndingCardNumber, opt => opt.MapFrom(src => src.EndingCardNumber))
            ;
            CreateMap<NewCreditCardDto, CreditCard>()
                .ForMember(dest => dest.FinancingEntityId, opt => opt.MapFrom(src => src.FinancingEntityId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.ShortName))
                //.ForMember(dest => dest.CreditValue, opt => opt.MapFrom(src => Money(src.Credit)))
                //.ForMember(dest => dest.UsedCreditValue, opt => opt.MapFrom(src => Money(src.UsedCredit)))
                .ForMember(dest => dest.Credit, opt => opt.MapFrom(src => src.Credit))
                .ForMember(dest => dest.UsedCredit, opt => opt.MapFrom(src => src.UsedCredit))
                .ForMember(dest => dest.ClosingDay, opt => opt.MapFrom(src => src.ClosingDay))
                .ForMember(dest => dest.DueDay, opt => opt.MapFrom(src => src.DueDay))
                .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => src.ExpirationDate))
                .ForMember(dest => dest.CardType, opt => opt.MapFrom(src => src.CardType))
                //.ForMember(dest => dest.CardTypeId, opt => opt.MapFrom(src => src.CardType))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.EndingCardNumber, opt => opt.MapFrom(src => src.EndingCardNumber))
                ;

        }

        protected string Clean(string? value)
        {
            if (value == null)
                return "";
            return value.Trim();
        }

        protected string Money(double? value)
        {
            if (value == null)
                return string.Format("{0:C2}", 0);
            return string.Format("{0:C2}", value);
        }

        protected FinancingEntityType MapFinancingEntityType(string? value) =>
            value != null ? value.GetFinancingEntityType() : FinancingEntityType.NOT_ESPECIFIED;

        protected CardType MapCardType(string? value) =>
           value != null ? value.GetCardType() : CardType.OTHER;

    }
}
