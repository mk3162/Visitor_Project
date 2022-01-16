using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
   public interface IPermisionService
    {
        IQueryable<Permision> GetAllAsQueryable();
        IEnumerable<Permision> GetAllAsEnumerable();
        List<Permision> GetAllAsList();

        Permision Get(Guid id);

        Permision Add(Permision entity);
        Permision Update(Permision entity);
        Permision Delete(Guid id);
    }
}
