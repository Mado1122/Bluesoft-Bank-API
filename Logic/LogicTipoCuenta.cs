using Entitys;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{   

    public class LogicTipoCuenta
    {   
        BlueSoftBankEntities DB { get; set; }

        public LogicTipoCuenta() { 
            DB = new BlueSoftBankEntities();
        }

        public ResultGeneral CrearTipoCuenta(Entitys.TipoCuenta TipoCuentaACrear)
        {
            try
            {
                Model.TipoCuenta TipoCuenta = new Model.TipoCuenta
                {
                   IdTipoCuenta = TipoCuentaACrear.IdTipoCuenta,
                   Descripcion = TipoCuentaACrear.Descripcion
                };

               DB.TipoCuentas.Add(TipoCuenta);

                DB.SaveChanges();

                return new ResultGeneral { Error = false , Message = "Se agrego correctamente" };

            }
            catch (Exception ex)
            {
                return new ResultGeneral { Error = true, Message = ex.Message };
            }
            
        }

        public ResultGeneral ConsultarTipoCuentas()
        {
            try
            {
                List<Entitys.TipoCuenta> Result = DB.TipoCuentas.Select(tp => new Entitys.TipoCuenta () { 

                    IdTipoCuenta = tp.IdTipoCuenta,
                    Descripcion = tp.Descripcion

                }).ToList();

                return new ResultGeneral { Error = false, Message = "Consulta Exitosa", ListTipoCuentas = Result };

            }
            catch(Exception ex)
            {
                return new ResultGeneral { Error = true, Message = ex.Message };
            }
        }


    }
}
