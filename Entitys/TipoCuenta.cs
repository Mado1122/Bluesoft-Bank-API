using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    [DataContract]
    public class TipoCuenta
    {
        public TipoCuenta()
        {
            this.Cuentas = new HashSet<Cuenta>();
        }
        [DataMember]
        public string IdTipoCuenta { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public virtual ICollection<Cuenta> Cuentas { get; set; }
    }
    }
