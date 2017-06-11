using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajeroAutomatico.Entities.Entities;
using CajeroAutomatico.Entities.IRepositories;

namespace CajeroAutomatico.Persistencia.Repositories
{
    public class EstadoDispensadorRepository : Repository<EstadoDispensador>, IEstadoDispensadorRepository
    {


        public EstadoDispensadorRepository(CajeroAutomaticoDBContext context) : base(context)
        {


        }


    }
}
