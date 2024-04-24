using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    [DataContract]
    public class Movimiento
    {
        [DataMember]
        public int IdMovimiento { get; set; }
        [DataMember]
        public Nullable<double> Valor { get; set; }
        [DataMember]
        public Nullable<System.DateTime> Fecha { get; set; }
        [DataMember]
        public string CiudadOrigen { get; set; }
        [DataMember]
        public Nullable<int> NumeroCuenta { get; set; }
        [DataMember]
        public virtual Cuenta Cuenta { get; set; }
    }
}
