using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
   public interface IVisitPointService
    {
        IQueryable<VisitPoint> GetAllAsQueryable();
        IEnumerable<VisitPoint> GetAllAsEnumerable();
        List<VisitPoint> GetAllAsList();

        VisitPoint Get(Guid id);

        VisitPoint Add(VisitPoint entity);
        VisitPoint Update(VisitPoint entity);
        VisitPoint Delete(Guid id);
    }
}
