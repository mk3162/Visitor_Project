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
    public class DepartmentManager : IDepartmentService
    {
        private IDepartmentDAL _departmentDAL;
        public DepartmentManager(IDepartmentDAL departmentDAL)
        {
            _departmentDAL = departmentDAL;
        }
        public Department Add(Department entity)
        {
            return _departmentDAL.Add(entity);
        }

        public Department Delete(Guid id)
        {
            var entity = _departmentDAL.Get(x => x.Id == id);
            entity.DeletedDate = DateTime.Now;
            entity.IsDeleted = true;
            return _departmentDAL.Update(entity);
        }

        public Department Get(Guid id)
        {
            return _departmentDAL.Get(x => x.Id == id);
        }

        public IEnumerable<Department> GetAllAsEnumerable()
        {
            return _departmentDAL.GetAllAsEnumerable();
        }

        public List<Department> GetAllAsList()
        {
            return _departmentDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<Department> GetAllAsQueryable()
        {
            return _departmentDAL.GetAllAsQueryable();
        }

        public Department Update(Department entity)
        {
            entity.ModifiedDate = DateTime.Now;
            return _departmentDAL.Update(entity);
        }
    }
}
