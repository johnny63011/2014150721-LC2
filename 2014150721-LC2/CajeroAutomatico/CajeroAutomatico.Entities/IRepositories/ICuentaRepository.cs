using CajeroAutomatico.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico.Entities.IRepositories
{
    public interface ICuentaRepository : IRepository<Cuenta>
    {


        List<Cuenta> GetMovimientos(int idCuenta);



        decimal ObtenerSaldoDisponible(int numeroCuenta);

        decimal ObtenerSaldoTotal(int numeroCuenta);

        void Debitar(int numeroCuenta, decimal monto);


        void Acreditar(int numeroCuenta, decimal monto);



    }
}
