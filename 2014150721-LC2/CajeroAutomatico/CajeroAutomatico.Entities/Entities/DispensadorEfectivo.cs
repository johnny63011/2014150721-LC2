using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CajeroAutomatico.Entities.Entities
{
    [Table("DispensadorEfectivos")]
    public class DispensadorEfectivo
    {
        [Key]
        public int dispensadorEfectivoId { get; set; }


        [Required,MaxLength(100)]
        public String ubicacion { get; set; }


        [Required]
        public int dineroTotal { get; set; }

        
        [Required]
        public int estadoDispensadorId { get; set; }

        [ForeignKey("estadoDispensadorId")]
        public EstadoDispensador EstadoDispensador { get; set; }



    }
}
