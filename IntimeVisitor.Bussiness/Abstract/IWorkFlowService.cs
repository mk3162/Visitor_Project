using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
   public interface IWorkFlowService
    {
        IQueryable<Workflow> GetAllAsQueryable();
        IEnumerable<Workflow> GetAllAsEnumerable();
        List<Workflow> GetAllAsList();

        Workflow Get(Guid id);

        Workflow Add(Workflow entity);
        Workflow Update(Workflow entity);
        Workflow Delete(Guid id);
    }
}
