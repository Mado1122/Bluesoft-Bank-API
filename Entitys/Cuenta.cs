using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    [DataContract]
    public class Cuenta
    {
        [DataMember]
        public int NumeroCuenta { get; set; }
        [DataMember]
        public Nullable<double> Saldo { get; set; }
        [DataMember]
        public string CiudadOrigen { get; set; }
        [DataMember]
        public string IdTipoCuenta { get; set; }
        [DataMember]
        public virtual TipoCuenta TipoCuenta { get; set; }
        [DataMember]
        public virtual ICollection<Movimiento> Movimientoes { get; set; }
    }
}
