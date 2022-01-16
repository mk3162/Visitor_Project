using IntimeVisitor.Bussiness.Abstract;
using IntimeVisitor.DataAccess.Abstract;
using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Concrete
{
    public class WorkFlowStepsManager : IWorkFlowStepsService
    {
        private IWorkFlowStepsDAL _workFlowStepsDAL;
        public WorkFlowStepsManager(IWorkFlowStepsDAL workFlowStepsDAL)
        {
            _workFlowStepsDAL = workFlowStepsDAL;
        }
        public WorkflowSteps Add(WorkflowSteps entity)
        {
            entity.CreatedDate = DateTime.Now;
            return _workFlowStepsDAL.Add(entity);
            throw new NotImplementedException();
        }

        

        public WorkflowSteps Delete(Guid id)
        {
            var entity = _workFlowStepsDAL.Get(x => x.Id == id);
            entity.DeletedDate = DateTime.Now;
            entity.IsDeleted = true;
            return _workFlowStepsDAL.Delete(entity);
        }

        public WorkflowSteps Get(Guid id)
        {
            return _workFlowStepsDAL.Get(x => x.Id == id);
        }

        public IEnumerable<WorkflowSteps> GetAllAsEnumerable()
        {
            return _workFlowStepsDAL.GetAllAsEnumerable();
        }

        public List<WorkflowSteps> GetAllAsList()
        {
            return _workFlowStepsDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<WorkflowSteps> GetAllAsQueryable()
        {
            return _workFlowStepsDAL.GetAllAsQueryable();
        }

        

        public WorkflowSteps Update(WorkflowSteps entity)
        {
            entity.ModifiedDate = DateTime.Now;
            return _workFlowStepsDAL.Update(entity);
        }
    }
}
