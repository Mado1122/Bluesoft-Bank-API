using Entitys;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{   

    public class LogicMovimiento
    {   
        BlueSoftBankEntities DB { get; set; }

        public LogicMovimiento() { 
            DB = new BlueSoftBankEntities();
        }

        public ResultGeneral Consignar( Entitys.Movimiento MovimientoO)
        {
            try
            {
                DB.Movimientoes.Add(new Model.Movimiento
                {
                    CiudadOrigen = MovimientoO.CiudadOrigen,
                    NumeroCuenta = MovimientoO.NumeroCuenta,
                    Fecha = MovimientoO.Fecha,
                    Valor = MovimientoO.Valor

                });

                DB.Cuentas.FirstOrDefault(c => c.NumeroCuenta == MovimientoO.NumeroCuenta).Saldo += MovimientoO.Valor;
                DB.SaveChanges();

                return new ResultGeneral { Error = false , Message = "Se agrego el saldo correctamente" };

            }
            catch (Exception ex)
            {
                return new ResultGeneral { Error = true, Message = ex.Message };
            }
            
        }

        public ResultGeneral Retirar(Entitys.Movimiento MovimientoO)
        {
            try
            {
                DB.Movimientoes.Add(new Model.Movimiento
                {
                    CiudadOrigen = MovimientoO.CiudadOrigen,
                    NumeroCuenta = MovimientoO.NumeroCuenta,
                    Fecha = MovimientoO.Fecha,
                    Valor = MovimientoO.Valor * -1

                });

                Model.Cuenta cuenta = DB.Cuentas.FirstOrDefault(c => c.NumeroCuenta == MovimientoO.NumeroCuenta);

                if(cuenta.Saldo >= MovimientoO.Valor)
                {
                    cuenta.Saldo -= MovimientoO.Valor;
                }

                else
                {
                    return new ResultGeneral { Error = true, Message = "Saldo insuficiente" };
                }
                
                DB.SaveChanges();

                return new ResultGeneral { Error = false, Message = "Se Retiro el saldo correctamente" };

            }
            catch (Exception ex)
            {
                return new ResultGeneral { Error = true, Message = ex.Message };
            }

        }

        public ResultGeneral ConsultarMovimientos(Entitys.Cuenta CuentaO,int Limit = 50)
        {
            try
            {
                List<Entitys.Movimiento> Movimientos = DB.Movimientoes.Where(m => m.NumeroCuenta == CuentaO.NumeroCuenta).
                     Select(m => new Entitys.Movimiento()
                     {
                         CiudadOrigen=m.CiudadOrigen,
                         Fecha= m.Fecha,
                         IdMovimiento=m.IdMovimiento,
                         Valor=m.Valor,
                         NumeroCuenta=m.NumeroCuenta

                     }).Take(Limit).ToList();

                return new ResultGeneral { Error = false, Message = "Consulta realizada correctamente",ListMovimientos = Movimientos };

            }
            catch (Exception ex)
            {
                return new ResultGeneral { Error = true, Message = ex.Message };
            }

        }

        public ResultGeneral ClientesTransaccionesMes(int mes)
        {
            try
            {
               List<Entitys.Cuenta> Cuentas = DB.Cuentas.Where(c => c.Movimientoes.Count >= 1 && c.Movimientoes.Any(m => m.Fecha.Value.Month == mes)).
                    Select( m => new Entitys.Cuenta() { 
                        
                        CiudadOrigen = m.CiudadOrigen,
                        IdTipoCuenta = m.IdTipoCuenta,
                        NumeroCuenta = m.NumeroCuenta,
                        Saldo = m.Saldo

                    } ).OrderByDescending(c=> c.NumeroCuenta).ToList();

                return new ResultGeneral { Error = false, Message = "Consulta realizada correctamente",ListCuentas = Cuentas };

            }
            catch (Exception ex)
            {
                return new ResultGeneral { Error = true, Message = ex.Message };
            }

        }

        public ResultGeneral ClientesRetiranFueraCiudad(int ValorMaximo)
        {
            try
            {
                List<Entitys.Cuenta> Cuentas = DB.Cuentas.Where(c => c.Movimientoes.Where(m => m.CiudadOrigen != c.CiudadOrigen).Sum(cc => cc.Valor < 0 ?  cc.Valor * -1 : cc.Valor) > ValorMaximo).
                     Select(m => new Entitys.Cuenta()
                     {

                         CiudadOrigen = m.CiudadOrigen,
                         IdTipoCuenta = m.IdTipoCuenta,
                         NumeroCuenta = m.NumeroCuenta,
                         Saldo = m.Saldo

                     }).ToList();

                return new ResultGeneral { Error = false, Message = "Consulta realizada correctamente", ListCuentas = Cuentas };

            }
            catch (Exception ex)
            {
                return new ResultGeneral { Error = true, Message = ex.Message };
            }

        }

    }
}
