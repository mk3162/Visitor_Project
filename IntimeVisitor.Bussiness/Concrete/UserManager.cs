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
    public class UserManager : IUserService
    {
        private IUserDAL _userDAL;
        public UserManager(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }
        public User Add(User entity)
        {

            return _userDAL.Add(entity);
        }

        public User Delete(Guid id)
        {
            var entity = _userDAL.Get(x => x.Id == id);
            entity.IsDeleted = true;
            entity.DeletedDate = DateTime.Now;
            return _userDAL.Update(entity);
        }

        public User Get(Guid id)
        {
            return _userDAL.Get(x => x.Id == id);
        }

        public IEnumerable<User> GetAllAsEnumerable()
        {
            return _userDAL.GetAllAsEnumerable();
        }

        public List<User> GetAllAsList()
        {
            return _userDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<User> GetAllAsQueryable()
        {
            return _userDAL.GetAllAsQueryable();
        }

        public User Update(User entity)
        {
            entity.ModifiedDate = DateTime.Now;
            return _userDAL.Update(entity);
        }
    }
}
