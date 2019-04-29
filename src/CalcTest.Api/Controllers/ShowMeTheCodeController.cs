using Microsoft.AspNetCore.Mvc;

namespace CalcTest.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                GitHub = "https://github.com/maxbruno/calctest",
                Azure = "https://calcularjuroscompostos.azurewebsites.net/api/v1/juroscompostos/calculajuros?valorinicial=100&meses=6"
            });
        }

    }
}