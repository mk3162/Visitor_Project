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
    public class VisitManager : IVisitService
    {
        private IVisitDAL _visitDAL;
        public VisitManager(IVisitDAL visitDAL)
        {
            _visitDAL = visitDAL;
        }
        public Visit Add(Visit entity)
        {
            entity.CreatedDate = DateTime.Now;
            return _visitDAL.Add(entity);
        }

        public Visit Delete(Guid id)
        {
            var entity = _visitDAL.Get(x => x.Id == id);
            entity.DeletedDate = DateTime.Now;
            entity.IsDeleted = true;
            return _visitDAL.Delete(entity);
        }

        public Visit Get(Guid id)
        {
            return _visitDAL.Get(x => x.Id == id);
        }

        public IEnumerable<Visit> GetAllAsEnumerable()
        {
            return _visitDAL.GetAllAsEnumerable();
        }

        public List<Visit> GetAllAsList()
        {
            return _visitDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<Visit> GetAllAsQueryable()
        {
            return _visitDAL.GetAllAsQueryable();
        }

        public Visit Update(Visit entity)
        {
            entity.ModifiedDate = DateTime.Now;
            return _visitDAL.Update(entity);
        }
    }
}
