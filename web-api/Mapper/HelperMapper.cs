using AutoMapper;
using Nameless.Ledger.Models;
using Nameless.Ledger.ModelsDto;

namespace Nameless.WebApi.Mapper
{
    public class HelperMapper : Profile
    {
        public HelperMapper()
        {
            #region Mapper Test
            CreateMap<TestModel, TestModelDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            CreateMap<TestModelDto, TestModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            #endregion

        }

    }
}
