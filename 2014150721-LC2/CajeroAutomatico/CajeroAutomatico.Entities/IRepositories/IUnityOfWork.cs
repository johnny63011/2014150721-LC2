using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico.Entities.IRepositories
{
  public  interface IUnityOfWork : IDisposable
    {

    
        IAtmRepository Atm { get; }
        IClienteRepository Clientes { get; }
        ICuentaRepository Cuentas { get; }
        IDispensadorEfectivoRepository DispensadorEfectivos { get; }
        IEstadoDispensadorRepository EstadoDispensadores { get; }
        IRetiroRepository Retiros { get; }
        ITipoCuentaRepository TipoCuentas { get; }



        //Método que guardará los cambios en la base de datos.
        int SaveChanges();

        void StateModified(object Entity);



    }
}
