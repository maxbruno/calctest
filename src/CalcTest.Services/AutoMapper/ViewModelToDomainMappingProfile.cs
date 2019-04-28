using AutoMapper;
using CalcTest.Domain.Model;
using CalcTest.Service.ViewModels;

namespace CalcTest.Service.Automapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<JurosCompostosViewModel, JurosCompostos>()
                .ConstructUsing(vm => new JurosCompostos(vm.ValorInicial, vm.Meses));
        }
    }
}
