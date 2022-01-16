using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
   public interface ITitleService
    {
        IQueryable<Title> GetAllAsQueryable();
        IEnumerable<Title> GetAllAsEnumerable();
        List<Title> GetAllAsList();

        Title Get(Guid id);

        Title Add(Title entity);
        Title Update(Title entity);
        Title Delete(Guid id);
    }
}
