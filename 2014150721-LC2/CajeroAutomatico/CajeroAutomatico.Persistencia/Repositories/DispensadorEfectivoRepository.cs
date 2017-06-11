using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajeroAutomatico.Entities.Entities;
using CajeroAutomatico.Entities.IRepositories;

namespace CajeroAutomatico.Persistencia.Repositories
{
   public class DispensadorEfectivoRepository : Repository<DispensadorEfectivo>,  IDispensadorEfectivoRepository
    {


        public DispensadorEfectivoRepository(CajeroAutomaticoDBContext context) : base(context)
        {


        }


    }
}
