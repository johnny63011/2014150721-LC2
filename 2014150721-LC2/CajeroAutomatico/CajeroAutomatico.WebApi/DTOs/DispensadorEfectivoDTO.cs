using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CajeroAutomatico.WebApi.DTOs
{
    public class DispensadorEfectivoDTO
    {

        public int dispensadorEfectivoId { get; set; }


       
        public String ubicacion { get; set; }


        
        public int dineroTotal { get; set; }


        
        public int estadoDispensadorId { get; set; }

       
        public EstadoDispensadorDTO EstadoDispensador { get; set; }


    }
}