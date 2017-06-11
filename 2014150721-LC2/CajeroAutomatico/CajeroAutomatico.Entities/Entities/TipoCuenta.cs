using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico.Entities.Entities
{
    public class TipoCuenta
    {
        [Key]
        public int tipoCuentaId { get; set; }


        [MaxLength(50),Required,DisplayName("Cuenta")]
        public String desTipoCuenta { get; set; }

    }
}
