using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico.Entities.Entities
{

    [Table("Retiros")]
    public class Retiro
    {

        [Key]
        public int retiroId { get; set; }

        [Required]
        public DateTime fechaRetiro    { get; set; }


        [Required]
        public DateTime montoRetiro { get; set; }


        public int atmId { get; set; }
        [ForeignKey("atmId")]
        public ATM Atm { get; set; }

       
        
        public int dispensadorEfectivoId { get; set; }

        [ForeignKey("dispensadorEfectivoId")]
        public DispensadorEfectivo DispensadorEfectivo { get; set; }



    }
}
