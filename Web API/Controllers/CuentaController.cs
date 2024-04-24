using Entitys;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuentaController : ControllerBase
    {
       
        private Logic.LogicCuenta Logica = new Logic.LogicCuenta();

        [HttpPost("CrearCuenta")]
        public ResultGeneral CrearCuenta( Entitys.Cuenta Cuenta)
        {
            return Logica.CrearCuenta(Cuenta);
        }

        [HttpGet("ConsultarSaldo/{NumeroCuenta}")]
        public ResultGeneral ConsultarSaldo(int NumeroCuenta)
        {
            return Logica.ConsultarSaldo(new Cuenta { NumeroCuenta= NumeroCuenta });
        }
    }
}
