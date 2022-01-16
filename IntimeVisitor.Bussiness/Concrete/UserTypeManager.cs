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
    public class UserTypeManager : IUserTypeService
    {
        private IUserTypeDAL _userTypeDAL;
        public UserTypeManager(IUserTypeDAL userTypeDAL)
        {
            _userTypeDAL = userTypeDAL;
        }
        public UserType Add(UserType entity)
        {
            return _userTypeDAL.Add(entity);
        }

        public UserType Delete(Guid id)
        {
            var entity = _userTypeDAL.Get(x => x.Id == id);
            entity.IsDeleted = true;
            entity.DeletedDate = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            return _userTypeDAL.Update(entity);
        }

        public UserType Get(Guid id)
        {
            return _userTypeDAL.Get(x => x.Id == id);
        }

        public IEnumerable<UserType> GetAllAsEnumerable()
        {
            return _userTypeDAL.GetAllAsEnumerable();
        }

        public List<UserType> GetAllAsList()
        {
            return _userTypeDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<UserType> GetAllAsQueryable()
        {
            return _userTypeDAL.GetAllAsQueryable();
        }

        public UserType Update(UserType entity)
        {
            entity.ModifiedDate = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            return _userTypeDAL.Update(entity);
        }
    }
}
