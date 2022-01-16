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
    public class BranchManager //: IBranchService
    {
        public IBranchDAL _branchDAL { get; set; }
        public BranchManager(IBranchDAL branchDAL)
        {
            _branchDAL = branchDAL;
        }
        public Branch Add(Branch entity)
        {
            entity.Location = "-";
            return _branchDAL.Add(entity);
        }

        public Branch Delete(Guid id)
        {
            var branch = _branchDAL.Get(x => x.Id == id);
            branch.IsDeleted = true;
            branch.DeletedDate = DateTime.Now;
            return _branchDAL.Update(branch);
        }

        public Branch Get(Guid id)
        {
            return _branchDAL.Get(x => x.Id == id);
        }

        public IEnumerable<Branch> GetAllAsEnumerable()
        {
            return _branchDAL.GetAllAsEnumerable();
        }

        public List<Branch> GetAllAsList()
        {
            return _branchDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<Branch> GetAllAsQueryable()
        {
            return _branchDAL.GetAllAsQueryable();
        }

        public Branch Update(Branch entity)
        {
            entity.ModifiedDate = DateTime.Now;
            return _branchDAL.Update(entity);
        }
    }
}
