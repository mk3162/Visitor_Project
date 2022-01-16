using IntimeVisitor.Entities.Domain;
using IntimeVisitor.Entities.ViewModel.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
    public interface IBranchService
    {
        IQueryable<Branch> GetAllAsQueryable();
        IEnumerable<Branch> GetAllAsEnumerable();
        List<Branch> GetAllAsList();
        BranchViewModel Fill(BranchViewModel model);
        Branch Get(Guid id);
        IQueryable<Branch> GetAll();
        Branch Add(Branch entity);
        Branch Update(Branch entity);
        Branch Delete(Guid id);
    }
}
