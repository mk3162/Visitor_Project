using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
   public interface IDepartmentService
    {
        IQueryable<Department> GetAllAsQueryable();
        IEnumerable<Department> GetAllAsEnumerable();
        List<Department> GetAllAsList();

        Department Get(Guid id);

        Department Add(Department entity);
        Department Update(Department entity);
        Department Delete(Guid id);
    }
}
