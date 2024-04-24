using Entitys;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoCuentaController : ControllerBase
    {
       
        private Logic.LogicTipoCuenta Logica = new Logic.LogicTipoCuenta();

        [HttpPost("CrearTipoCuenta")]
        public ResultGeneral CrearTipoCuenta( Entitys.TipoCuenta TipoCuenta)
        {
            return Logica.CrearTipoCuenta(TipoCuenta);
        }

        [HttpGet("ConsultarTipoCuentas")]
        public ResultGeneral ConsultarTipoCuentas()
        {
            return Logica.ConsultarTipoCuentas();
        }
    }
}
