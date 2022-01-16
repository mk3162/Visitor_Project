using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
   public interface IUserRolesService
    {
        IQueryable<UserRoles> GetAllAsQueryable();
        IEnumerable<UserRoles> GetAllAsEnumerable();
        List<UserRoles> GetAllAsList();

        UserRoles Get(Guid id);

        UserRoles Add(UserRoles entity);
        UserRoles Update(UserRoles entity);
        UserRoles Delete(Guid id);
    }
}
