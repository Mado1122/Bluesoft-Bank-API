using Entitys;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimientoController : ControllerBase
    {
       
        private Logic.LogicMovimiento Logica = new Logic.LogicMovimiento();
        [HttpPost("Consignar/{Valor}/{CiudadOrigen}/{NumeroCuenta}")]
        public ResultGeneral Consignar( float Valor,string CiudadOrigen, int NumeroCuenta)
        {
            return Logica.Consignar(new Movimiento
            {
                CiudadOrigen = CiudadOrigen,
                Valor = Valor,
                NumeroCuenta = NumeroCuenta,
                Fecha = DateTime.Now
            });
        }

        [HttpPost("Retirar/{Valor}/{CiudadOrigen}/{NumeroCuenta}")]
        public ResultGeneral Retirar(float Valor, string CiudadOrigen, int NumeroCuenta)
        {
            return Logica.Retirar(new Movimiento
            {
                CiudadOrigen = CiudadOrigen,
                Valor = Valor,
                NumeroCuenta = NumeroCuenta,
                Fecha = DateTime.Now
            });
        }

        [HttpGet("ConsultarMovimientos/{numeroCuenta}/{Limit}")]
        public ResultGeneral ConsultarMovimientos(int numeroCuenta, int Limit = 50)
        {
            return Logica.ConsultarMovimientos(new Cuenta { NumeroCuenta = numeroCuenta}, Limit);
        }

        [HttpGet("ClientesTransaccionesMes/{mes}")]
        public ResultGeneral ClientesTransaccionesMes(int mes)
        {
            return Logica.ClientesTransaccionesMes(mes);
        }

        [HttpGet("ClientesRetiranFueraCiudad/{valorMaximo}")]
        public ResultGeneral ClientesRetiranFueraCiudad(int valorMaximo)
        {
            return Logica.ClientesRetiranFueraCiudad(valorMaximo);
        }
    }
}
