using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
    public interface IBranchTypeService
    {
        IQueryable<BranchType> GetAllAsQueryable();
        IEnumerable<BranchType> GetAllAsEnumerable();
        List<BranchType> GetAllAsList();
       // BranchViewModel Fill(BranchViewModel model);
        BranchType Get(Guid id);
        IQueryable<BranchType> GetAll();
        BranchType Add(BranchType entity);
        BranchType Update(BranchType entity);
        BranchType Delete(Guid id);
    }
}
