using CalcTest.Domain.Interfaces;
using CalcTest.Service.Interfaces;
using CalcTest.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CalcTest.Api.Controllers
{
    [Route("api/v1/[controller]/calculajuros")]
    [ApiController]
    public class JurosCompostosController : ControllerBase
    {
        private readonly IJurosCompostosService _jurosCompostosService;
        private readonly IDomainNotification _domainNotification;

        public JurosCompostosController(IJurosCompostosService jurosCompostosService,
            IDomainNotification domainNotification)
        {
            _jurosCompostosService = jurosCompostosService;
            _domainNotification = domainNotification;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]JurosCompostosViewModel vm)
        {
            var teste = _jurosCompostosService.Calcular(vm).Result;
            return Ok(teste);
        }
    }
}