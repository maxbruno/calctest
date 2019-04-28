using AutoMapper;
using CalcTest.Domain.Interfaces;
using CalcTest.Domain.Model;
using CalcTest.Service.Interfaces;
using CalcTest.Service.ViewModels;
using System;
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
            try
            {
                var jurosCompostos = _mapper.Map<JurosCompostos>(vm);
                if (jurosCompostos.Validar())
                    return Task.FromResult(_mapper.Map<JurosCompostosResultViewModel>(jurosCompostos));

                _domainNotification.AddNotification("Valores", "Valores inválidos");
            }
            catch (InvalidOperationException)
            {
                _domainNotification.AddNotification("Pârâmetros", "Erro ao calcular o juros compostos");
            }
            catch (OverflowException)
            {
                _domainNotification.AddNotification("Pârâmetros", "O servidor não consegue calcular com os parâmetros fornecidos");
            }
            catch (AutoMapperMappingException ex) when (ex.GetBaseException() is OverflowException)
            {
                _domainNotification.AddNotification("Pârâmetros", "O servidor não consegue calcular com os parâmetros fornecidos");
            }

            return Task.FromResult<JurosCompostosResultViewModel>(null);
        }
    }
}
