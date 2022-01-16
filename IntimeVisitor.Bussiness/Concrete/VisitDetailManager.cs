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
    public class VisitDetailManager : IVisitDetailService
    {
        private IVisitDetailDAL _visitDetailDAL;
        public VisitDetailManager(IVisitDetailDAL visitDetailDAL)
        {
            _visitDetailDAL = visitDetailDAL;
        }
        public VisitDetail Add(VisitDetail entity)
        {
            entity.CreatedDate = DateTime.Now;
            return _visitDetailDAL.Add(entity);
            throw new NotImplementedException();
        }

        public VisitDetail Delete(Guid id)
        {
            var entity = _visitDetailDAL.Get(x => x.Id == id);
            entity.DeletedDate = DateTime.Now;
            entity.IsDeleted = true;
            return _visitDetailDAL.Delete(entity);
        }

        public VisitDetail Get(Guid id)
        {
            return _visitDetailDAL.Get(x => x.Id == id);
        }

        public IEnumerable<VisitDetail> GetAllAsEnumerable()
        {
            return _visitDetailDAL.GetAllAsEnumerable();
        }

        public List<VisitDetail> GetAllAsList()
        {
            return _visitDetailDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<VisitDetail> GetAllAsQueryable()
        {
            return _visitDetailDAL.GetAllAsQueryable();
        }

        public VisitDetail Update(VisitDetail entity)
        {
            entity.ModifiedDate = DateTime.Now;
            return _visitDetailDAL.Update(entity);
        }
    }
}
