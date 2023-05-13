using AutoMapper;
using CalculatorAPI.Entities;
using CalculatorAPI.ViewModel;

namespace CalculatorAPI.Mapping
{
    public class Mapper : Profile
    {

        public Mapper()
        {
            CreateMap<Calculator, CalculatorViewModel>();
            CreateMap<CalculatorViewModel, Calculator>()
                .ForMember(src => src.Id, opt => opt.Ignore());
        }
    }
}
