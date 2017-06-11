
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajeroAutomatico.Entities.Entities;
using CajeroAutomatico.Entities.IRepositories;

namespace CajeroAutomatico.Persistencia.Repositories
{
    public class TipoCuentaRepository : Repository<TipoCuenta>, ITipoCuentaRepository
    {

        public TipoCuentaRepository(CajeroAutomaticoDBContext context) : base(context)
        {


        }


    }
}
