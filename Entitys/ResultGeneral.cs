using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    [DataContract]
    public class ResultGeneral
    {
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public bool Error { get; set; }
        [DataMember]
        public object  Object { get; set; }
        [DataMember]
        public int Integer { get; set; }
        [DataMember]
        public List<TipoCuenta> ListTipoCuentas { get; set; }
        [DataMember]
        public List<Movimiento> ListMovimientos { get; set; }
        [DataMember]
        public List<Cuenta> ListCuentas { get; set; }
        [DataMember]
        public float Float { get; set; }

    }
}
