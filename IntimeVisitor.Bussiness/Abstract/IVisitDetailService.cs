using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
 public   interface IVisitDetailService
    {
        IQueryable<VisitDetail> GetAllAsQueryable();
        IEnumerable<VisitDetail> GetAllAsEnumerable();
        List<VisitDetail> GetAllAsList();

        VisitDetail Get(Guid id);

        VisitDetail Add(VisitDetail entity);
        VisitDetail Update(VisitDetail entity);
        VisitDetail Delete(Guid id);
    }
}
