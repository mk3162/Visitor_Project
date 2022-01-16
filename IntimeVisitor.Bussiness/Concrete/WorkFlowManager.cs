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
    public class WorkFlowManager : IWorkFlowService
    {
        private IWorkFlowDAL _workFlowDAL;
        public WorkFlowManager(IWorkFlowDAL workFlowDAL)
        {
            _workFlowDAL = workFlowDAL;
        }
        public Workflow Add(Workflow entity)
        {
            entity.CreatedDate = DateTime.Now;
            return _workFlowDAL.Add(entity);
        }

        public Workflow Delete(Guid id)
        {
            var entity = _workFlowDAL.Get(x => x.Id == id);
            entity.DeletedDate = DateTime.Now;
            entity.IsDeleted = true;
            return _workFlowDAL.Delete(entity);
        }

        public Workflow Get(Guid id)
        {
            return _workFlowDAL.Get(x => x.Id == id);
        }

        public IEnumerable<Workflow> GetAllAsEnumerable()
        {
            return _workFlowDAL.GetAllAsEnumerable();
        }

        public List<Workflow> GetAllAsList()
        {
            return _workFlowDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<Workflow> GetAllAsQueryable()
        {
            return _workFlowDAL.GetAllAsQueryable();
        }

        public Workflow Update(Workflow entity)
        {
            entity.ModifiedDate = DateTime.Now;
            return _workFlowDAL.Update(entity);
        }
    }
}
