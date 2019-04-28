using AutoMapper;
using CalcTest.Domain.Interfaces;
using CalcTest.Domain.Model;
using CalcTest.Service.Interfaces;
using CalcTest.Service.ViewModels;
using System.Threading.Tasks;

namespace CalcTest.Service.Services
{

    public class JurosCompostosService : IJurosCompostosService
    {
        private readonly IDomainNotification _domainNotification;
        private readonly IMapper _mapper;

        public JurosCompostosService(IMapper mapper,
            IDomainNotification domainNotification)
        {
            _domainNotification = domainNotification;
            _mapper = mapper;
        }

        public Task<JurosCompostosResultViewModel> Calcular(JurosCompostosViewModel vm)
        {
            var jurosCompostos = _mapper.Map<JurosCompostos>(vm);
            if (jurosCompostos.Validar())
                return Task.FromResult(_mapper.Map<JurosCompostosResultViewModel>(jurosCompostos));

            _domainNotification.AddNotification("Valores", "Valores inválidos");
            return Task.FromResult<JurosCompostosResultViewModel>(null);
        }
    }
}
