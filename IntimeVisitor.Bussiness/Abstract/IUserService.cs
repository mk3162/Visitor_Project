using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
   public interface IUserService
    {
        IQueryable<User> GetAllAsQueryable();
        IEnumerable<User> GetAllAsEnumerable();
        List<User> GetAllAsList();

        User Get(Guid id);

        User Add(User entity);
        User Update(User entity);
        User Delete(Guid id);
    }
}
