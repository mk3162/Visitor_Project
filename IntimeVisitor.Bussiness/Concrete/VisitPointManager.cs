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
    public class VisitPointManager : IVisitPointService
    {

        private IVisitPointDAL _visitPointDAL;
        public VisitPointManager(IVisitPointDAL visitPointDAL)
        {
            _visitPointDAL = visitPointDAL;
        }
        public VisitPoint Add(VisitPoint entity)
        {

            return _visitPointDAL.Add(entity);
      
        }

        public VisitPoint Delete(Guid id)
        {
            var entity = _visitPointDAL.Get(x => x.Id == id);
            entity.DeletedDate = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            entity.IsDeleted = true;
            return _visitPointDAL.Update(entity);
        }

        public VisitPoint Get(Guid id)
        {
            return _visitPointDAL.Get(x => x.Id == id);
        }

        public IEnumerable<VisitPoint> GetAllAsEnumerable()
        {
            return _visitPointDAL.GetAllAsEnumerable();
        }

        public List<VisitPoint> GetAllAsList()
        {
            return _visitPointDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<VisitPoint> GetAllAsQueryable()
        {
            return _visitPointDAL.GetAllAsQueryable();
        }

        public VisitPoint Update(VisitPoint entity)
        {
            entity.ModifiedDate = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            return _visitPointDAL.Update(entity);
        }
    }
}
