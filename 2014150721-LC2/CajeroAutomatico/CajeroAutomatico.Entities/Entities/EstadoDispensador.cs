using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CajeroAutomatico.Entities.Entities
{
    [Table("EstadoDispensadores")]
    public class EstadoDispensador
    {

        [Key]
        public int estadoDispensadorId { get; set; }

        [Required, DisplayName("Estado Dispensador")]
        public String desEstDispensador { get; set; }


    }
}
