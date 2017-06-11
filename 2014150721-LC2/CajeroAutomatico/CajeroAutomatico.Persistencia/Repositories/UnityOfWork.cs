
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajeroAutomatico.Entities.Entities;
using CajeroAutomatico.Entities.IRepositories;

namespace CajeroAutomatico.Persistencia.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {

        private readonly CajeroAutomaticoDBContext _Context;

        /*private static UnityOfWork _Instance;
        private static readonly object _Lock = new object();
        */


        public IClienteRepository Clientes  {get; private set; }

        public ICuentaRepository Cuentas { get; private set; }

        public IDispensadorEfectivoRepository DispensadorEfectivos { get; private set; }

        public IRetiroRepository Retiros { get; private set; }

        public ITipoCuentaRepository TipoCuentas { get; private set; }

        public IEstadoDispensadorRepository EstadoDispensadores { get; private set; }

        public IAtmRepository Atm { get; private set; }

        public UnityOfWork(){

        }

        public UnityOfWork(CajeroAutomaticoDBContext context)
        {

            _Context = context;

            Clientes = new ClienteRepository(_Context);
            Cuentas = new CuentaRepository(_Context);
            DispensadorEfectivos = new DispensadorEfectivoRepository(_Context);
            Retiros = new RetiroRepository(_Context);
            TipoCuentas = new TipoCuentaRepository(_Context);
            Atm = new AtmRepository(_Context);
            EstadoDispensadores = new EstadoDispensadorRepository(_Context);
        }

        /*
        public static UnityOfWork Instance
        {
            get
            {
                lock (_Lock)
                {
                    if (_Instance == null)
                        _Instance = new UnityOfWork();
                }

                return _Instance;
            }
        }
        */

        public void Dispose()
        {

            _Context.Dispose();
            

        }

        public int SaveChanges()
        {
            return _Context.SaveChanges();
        }

        public void StateModified(object Entity)
        {
            _Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
