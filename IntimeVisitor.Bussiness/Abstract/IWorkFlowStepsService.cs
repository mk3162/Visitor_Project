using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
     public interface IWorkFlowStepsService
    {
        IQueryable<WorkflowSteps> GetAllAsQueryable();
        IEnumerable<WorkflowSteps> GetAllAsEnumerable();
        List<WorkflowSteps> GetAllAsList();

        WorkflowSteps Get(Guid id);

        WorkflowSteps Add(WorkflowSteps entity);
        WorkflowSteps Update(WorkflowSteps entity);
        WorkflowSteps Delete(Guid id);
    }
}
