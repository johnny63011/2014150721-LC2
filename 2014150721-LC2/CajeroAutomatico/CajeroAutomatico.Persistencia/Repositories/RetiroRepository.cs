
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajeroAutomatico.Entities.Entities;
using CajeroAutomatico.Entities.IRepositories;


namespace CajeroAutomatico.Persistencia.Repositories
{
    public class RetiroRepository : Repository<Retiro>, IRetiroRepository
    {

       
        public RetiroRepository(CajeroAutomaticoDBContext context) : base(context)
        {


        }


        public IEnumerable<Cuenta> GetDinero(int idCuenta)
        {
            throw new NotImplementedException();
        }
    }
}
