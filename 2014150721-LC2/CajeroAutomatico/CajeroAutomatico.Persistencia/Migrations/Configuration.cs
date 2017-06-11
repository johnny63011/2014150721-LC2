namespace CajeroAutomatico.Persistencia.Migrations
{
    using CajeroAutomatico.Entities.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CajeroAutomatico.Persistencia.CajeroAutomaticoDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CajeroAutomatico.Persistencia.CajeroAutomaticoDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //




            context.TipoCuentas.AddOrUpdate(new TipoCuenta
            {
                tipoCuentaId = 1,
                desTipoCuenta = "Ahorros",
            });


            context.TipoCuentas.AddOrUpdate(new TipoCuenta
            {
                tipoCuentaId = 2,
                desTipoCuenta = "Premio",

            });

            context.TipoCuentas.AddOrUpdate(new TipoCuenta
            {
                tipoCuentaId = 3,
                desTipoCuenta = "Compras",

            });


            // Estado del cajero automatico

            context.EstadoDispensadores.AddOrUpdate(new EstadoDispensador
            {
                estadoDispensadorId = 1,
                desEstDispensador = "Averiado"

            });

            context.EstadoDispensadores.AddOrUpdate(new EstadoDispensador
            {
                estadoDispensadorId = 2,
                desEstDispensador = "Sin Efectivo"

            });

            context.EstadoDispensadores.AddOrUpdate(new EstadoDispensador
            {
                estadoDispensadorId = 3,
                desEstDispensador = "Mantenimiento"

            });


            context.Clientes.AddOrUpdate(new Cliente
            {
                clienteId = 1,
                nomcliente = "Juanito Perez",
                correoCliente = "juanito_perez@gmail.com",
                direcCliente = "jr. lima 563",
                telCliente = "987456321"

            });


            context.Clientes.AddOrUpdate(new Cliente
            {
                clienteId = 2,
                nomcliente = "Jose Perez",
                correoCliente = "jose_perez@gmail.com",
                direcCliente = "jr. camana 8693",
                telCliente = "96932681"

            });


            context.Cuentas.AddOrUpdate(new Cuenta
            {
                cuentaId = 1,
                numeroCuenta = 100036226,
                numTarjeta = "8292-1234-2323-3232",
                pin = 1234,
                saldoDisponible = 1200,
                tipoCuentaId = 1,
                clienteId = 1,
            });

            context.Cuentas.AddOrUpdate(new Cuenta
            {
                cuentaId = 2,
                numeroCuenta = 1878036226,
                numTarjeta = "8292-1039-22393-3232",
                pin = 4321,
                saldoDisponible = 1100,
                tipoCuentaId = 3,
                clienteId = 2,

            });




        }
    }
}
