using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
   public interface ICompanyService
    {
        IQueryable<Company> GetAllAsQueryable();
        IEnumerable<Company> GetAllAsEnumerable();
        List<Company> GetAllAsList();

        Company Get(Guid id);

        Company Add(Company entity);
        Company Update(Company entity);
        Company Delete(Guid id);
    }
}
