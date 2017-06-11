using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CajeroAutomatico.Entities.Entities
{
    public class BaseDatos
    {


        private decimal saldoTotal = 0;

        private bool autenticarUsuario = false;


        private Cuenta cuenta = new Cuenta();



        public bool AutenticarUsuario(int numeroCuenta, int pin)
        {

            Console.WriteLine("Ingrese su numero de cuenta:");
            Thread.Sleep(1500);
            Console.WriteLine("{0}", numeroCuenta);
            Thread.Sleep(1000);
            Console.WriteLine("Ingrese su numero de pin:");
            Thread.Sleep(1500);
            Console.WriteLine("****");
            Thread.Sleep(1000);


            if (numeroCuenta != cuenta.numeroCuenta)
            {
                Console.WriteLine("Numero de cuenta incorrecto");

            }
            else if (pin != cuenta.pin)
            {
                Console.WriteLine("PIN incorrecto");
            }
            else
            {
                Console.WriteLine("Ingreso correcto, seleccione su operacion.");
                autenticarUsuario = true;
            }

            Thread.Sleep(3500);
            return autenticarUsuario;

        }






        public decimal ObtenerSaldoDisponible(int numeroCuenta)
        {

            Console.WriteLine("Opción : Consulta saldo Disponible");
            Thread.Sleep(1500);


            Console.WriteLine("Su saldo es de:{0} ", cuenta.saldoDisponible);
            Thread.Sleep(1500);


            return cuenta.saldoDisponible;
        }









        public decimal ObtenerSaldoTotal(int numeroCuenta)
        {
            return saldoTotal;
        }






        public void Debitar(int numeroCuenta, decimal monto)
        {

            Console.WriteLine("Opcion: Debitar");
            Thread.Sleep(1500);


            Console.WriteLine("Ingrese el monto a debitar:");
            Thread.Sleep(1500);

            Console.WriteLine("{0}", monto);
            Thread.Sleep(1500);

            if (monto <= cuenta.saldoDisponible)
            {


                Console.WriteLine("Se debito {1} nuevos soles a la cuenta {0} .", numeroCuenta, monto);
                Thread.Sleep(1500);


                decimal saldoDisponible = cuenta.saldoDisponible - monto;

                Console.WriteLine("Su saldo disponible es de: {0}", saldoDisponible);
                Thread.Sleep(4500);



            }
            else
            {

                Console.WriteLine("El monto a debitar es mayor al saldo disponible");
                Thread.Sleep(4500);



            }





        }

        public void Acreditar(int numeroCuenta, decimal monto)
        {

        }









    }
}
