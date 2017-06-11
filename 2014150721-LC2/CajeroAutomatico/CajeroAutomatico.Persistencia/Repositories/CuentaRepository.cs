
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CajeroAutomatico.Entities.Entities;
using CajeroAutomatico.Entities.IRepositories;

namespace CajeroAutomatico.Persistencia.Repositories
{
    public class CuentaRepository : Repository<Cuenta>, ICuentaRepository
    {


        private  Cuenta cuenta;


        public CuentaRepository(CajeroAutomaticoDBContext context) : base(context)
        {
     

        }





        List<Cuenta> ICuentaRepository.GetMovimientos(int idCuenta)
        {

          

            Console.WriteLine("Usted ha realizado los siguientes Movimientos:");
            Thread.Sleep(1500);
            Console.WriteLine("Fecha:14/05/2017 - Monto:100 nuevos soles");
            Thread.Sleep(1000);
            Console.WriteLine("Fecha:15/05/2017 - Monto:50 nuevos soles");
            Thread.Sleep(1000);
            Console.WriteLine("Fecha:16/05/2017 - Monto:20 nuevos soles");
            Thread.Sleep(1000);
            Console.WriteLine("Fecha:17/05/2017 - Monto:40 nuevos soles");
            Thread.Sleep(1000);

            throw new NotImplementedException();
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
          

            return cuenta.saldoDisponible;


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
