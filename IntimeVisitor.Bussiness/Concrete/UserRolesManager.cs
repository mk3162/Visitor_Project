using IntimeVisitor.Bussiness.Abstract;
using IntimeVisitor.DataAccess.Concrete;
using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Concrete
{
    public class UserRolesManager : IUserRolesService
    {
        private UserRolesDAL _userRolesDAL;
        public UserRolesManager(UserRolesDAL userRolesDAL)
        {
            _userRolesDAL = userRolesDAL;
        }
        public UserRoles Add(UserRoles entity)
        {
            return _userRolesDAL.Add(entity);
        }

        public UserRoles Delete(Guid id)
        {
            var entity = _userRolesDAL.Get(x => x.Id == id);
            entity.DeletedDate = DateTime.Now;
            entity.IsDeleted = true;
            return _userRolesDAL.Delete(entity);
        }

        public UserRoles Get(Guid id)
        {
            return _userRolesDAL.Get(x => x.Id == id);
        }

        public IEnumerable<UserRoles> GetAllAsEnumerable()
        {
            return _userRolesDAL.GetAllAsEnumerable();
        }

        public List<UserRoles> GetAllAsList()
        {
            return _userRolesDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<UserRoles> GetAllAsQueryable()
        {
            return _userRolesDAL.GetAllAsQueryable();
        }

        public UserRoles Update(UserRoles entity)
        {
            entity.ModifiedDate = DateTime.Now;
            return _userRolesDAL.Update(entity);
        }
    }
}
