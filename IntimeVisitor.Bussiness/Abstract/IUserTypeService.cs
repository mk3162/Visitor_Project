using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
   public interface IUserTypeService
    {
        IQueryable<UserType> GetAllAsQueryable();
        IEnumerable<UserType> GetAllAsEnumerable();
        List<UserType> GetAllAsList();

        UserType Get(Guid id);

        UserType Add(UserType entity);
        UserType Update(UserType entity);
        UserType Delete(Guid id);
    }
}
