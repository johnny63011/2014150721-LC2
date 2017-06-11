using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CajeroAutomatico.WebApi.DTOs
{
    public class RetiroDTO
    {



      
        public int retiroId { get; set; }

      
        public DateTime fechaRetiro { get; set; }


      
        public DateTime montoRetiro { get; set; }


        public int atmId { get; set; }
       


        public AtmDTO Atm { get; set; }



        public int dispensadorEfectivoId { get; set; }

        
        public DispensadorEfectivoDTO DispensadorEfectivo { get; set; }


    }
}