using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
   public interface ICompanyTypeService
    {
        IQueryable<CompanyType> GetAllAsQueryable();
        IEnumerable<CompanyType> GetAllAsEnumerable();
        List<CompanyType> GetAllAsList();

        CompanyType Get(Guid id);

        CompanyType Add(CompanyType entity);
        CompanyType Update(CompanyType entity);
        CompanyType Delete(Guid id);
    }
}
