using CajeroAutomatico.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico.Console
{
    class Program
    {
        private static BaseDatos baseDatos = new BaseDatos();



        private static int numCuenta = 195292863;
        private static int pin = 1234;

        static void Main(string[] args)
        {


            bool autenticarUsuario = baseDatos.AutenticarUsuario(numCuenta, pin);

            if (autenticarUsuario == true)
            {

                baseDatos.ObtenerSaldoDisponible(numCuenta);


                baseDatos.Debitar(numCuenta, 100);




            }


        }
    }
}
