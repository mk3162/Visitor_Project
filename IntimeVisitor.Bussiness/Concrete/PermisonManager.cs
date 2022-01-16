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
    public class PermisonManager : IPermisionService
    {
        private IPermisionDAL _permisionDAL;
        public PermisonManager(IPermisionDAL permisionDAL)
        {
            _permisionDAL = permisionDAL;
        }
        public Permision Add(Permision entity)
        {
            return _permisionDAL.Add(entity);
        }

        public Permision Delete(Guid id)
        {
            var entity = _permisionDAL.Get(x => x.Id == id);
            entity.IsDeleted = true;
            entity.DeletedDate = DateTime.Now;
            return _permisionDAL.Update(entity);
        }

        public Permision Get(Guid id)
        {
            return _permisionDAL.Get(x => x.Id == id);
        }

        public IEnumerable<Permision> GetAllAsEnumerable()
        {
            return _permisionDAL.GetAllAsEnumerable();
        }

        public List<Permision> GetAllAsList()
        {
            return _permisionDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<Permision> GetAllAsQueryable()
        {
            return _permisionDAL.GetAllAsQueryable();
        }

        public Permision Update(Permision entity)
        {
            entity.ModifiedDate = DateTime.Now;
            return _permisionDAL.Update(entity);
        }
    }
}
