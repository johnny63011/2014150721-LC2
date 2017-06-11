using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CajeroAutomatico.WebApi.DTOs
{
    public class CuentaDTO
    {



        public int cuentaId { get; set; }

        public int numeroCuenta { get; set; }

        public String numTarjeta { get; set; }


        public int pin { get; set; }

        public decimal saldoDisponible { get; set; }

     
        public int tipoCuentaId { get; set; }

  
        public TipoCuentaDTO TipoCuenta { get; set; }

 
        // public Clien Cliente { get; set; }



    }
}