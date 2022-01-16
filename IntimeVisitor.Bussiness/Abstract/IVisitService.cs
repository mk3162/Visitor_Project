using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
   public interface IVisitService
    {
        IQueryable<Visit> GetAllAsQueryable();
        IEnumerable<Visit> GetAllAsEnumerable();
        List<Visit> GetAllAsList();

        Visit Get(Guid id);

        Visit Add(Visit entity);
        Visit Update(Visit entity);
        Visit Delete(Guid id);
    }
}
