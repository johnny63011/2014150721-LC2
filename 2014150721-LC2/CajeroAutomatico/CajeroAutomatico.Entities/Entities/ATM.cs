using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico.Entities.Entities
{
    [Table("Atms")]
    public class ATM
    {

        [Key]
        public int atmId { get; set; }


        [Required, DisplayName("Resultado")]
        public String desAtm { get; set; }


    }
}
