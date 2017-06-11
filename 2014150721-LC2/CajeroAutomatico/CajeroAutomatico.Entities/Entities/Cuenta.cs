using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CajeroAutomatico.Entities.Entities
{
    [Table("Cuentas")]
    public class Cuenta
    {
        [Key]
        public int cuentaId { get; set; }


        [Required, DisplayName("Número de Cuenta")]
        public int numeroCuenta { get; set; }

        [Required, MaxLength(20), DisplayName("Núm. Tarjeta")]
        public String numTarjeta { get; set; }


        [Required, DisplayName("Código Pin")]
        public int pin { get; set; }

        [DisplayName("Saldo Disponible")]
        public decimal saldoDisponible { get; set; }

        [Required]
        public int tipoCuentaId { get; set; }

        [ForeignKey("tipoCuentaId")]
        public TipoCuenta TipoCuenta { get; set; }

        [Required]
        public int clienteId { get; set; }
        [ForeignKey("clienteId")]
        public Cliente Cliente { get; set; }

    }
}
