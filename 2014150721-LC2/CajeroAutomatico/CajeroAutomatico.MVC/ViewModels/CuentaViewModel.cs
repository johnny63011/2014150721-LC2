
using CajeroAutomatico.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CajeroAutomatico.MVC.ViewModels
{
    public class CuentaViewModel
    {

        public IEnumerable<TipoCuenta> TipoCuentas { get; set; }


        public Cuenta Cuenta { get; set; }








    }
}