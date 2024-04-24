using Entitys;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{   

    public class LogicCuenta
    {   
        BlueSoftBankEntities DB { get; set; }

        public LogicCuenta() { 
            DB = new BlueSoftBankEntities();
        }

        public ResultGeneral CrearCuenta(Entitys.Cuenta CuentaACrear)
        {
            try
            {
                Model.Cuenta cuenta = new Model.Cuenta
                {
                    CiudadOrigen = CuentaACrear.CiudadOrigen,
                    IdTipoCuenta = CuentaACrear.IdTipoCuenta,
                    NumeroCuenta = CuentaACrear.NumeroCuenta,
                    Saldo = CuentaACrear.Saldo
                };

               DB.Cuentas.Add(cuenta);

                DB.SaveChanges();

                return new ResultGeneral { Error = false , Message = "Se agrego correctamente" };

            }
            catch (Exception ex)
            {
                return new ResultGeneral { Error = true, Message = ex.Message };
            }
            
        }

        public ResultGeneral ConsultarSaldo(Entitys.Cuenta CuentaValidar)
        {
            try
            {
                Model.Cuenta Cuenta = DB.Cuentas.FirstOrDefault(c => c.NumeroCuenta == CuentaValidar.NumeroCuenta);

                return new ResultGeneral { Error = false, Message = "Consulta Exitosa", Float = float.Parse(""+Cuenta.Saldo) };

            }
            catch(Exception ex)
            {
                return new ResultGeneral { Error = true, Message = ex.Message };
            }
        }


    }
}
