using Microsoft.AspNetCore.Mvc;

namespace ProductInventoryManager.Api.Controllers
{
    [Route("/")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IConfiguration p_Configuracion;
        public DefaultController(IConfiguration p_Configuracion)
        {
            this.p_Configuracion = p_Configuracion;
        }

        [HttpGet]
        public string Index()
        {
            return $"Running ...";
        }
    }
}