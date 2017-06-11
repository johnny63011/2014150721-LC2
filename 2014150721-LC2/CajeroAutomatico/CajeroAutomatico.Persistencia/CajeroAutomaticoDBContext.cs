using CajeroAutomatico.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico.Persistencia
{
    public class CajeroAutomaticoDBContext : DbContext
    {





        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<DispensadorEfectivo> DispensadorEfectivos { get; set; }
        public DbSet<Retiro> Retiros { get; set; }
        public DbSet<TipoCuenta> TipoCuentas { get; set; }
        public DbSet<EstadoDispensador> EstadoDispensadores { get; set; }
        public DbSet<ATM> Atm { get; set; }


        public CajeroAutomaticoDBContext() : base("CajeroAutomaticoDBContext")
        {

        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


        }




    }
}
