using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
  public  interface INotesService
    {
        IQueryable<Notes> GetAllAsQueryable();
        IEnumerable<Notes> GetAllAsEnumerable();
        List<Notes> GetAllAsList();

        Notes Get(Guid id);

        Notes Add(Notes entity);
        Notes Update(Notes entity);
        Notes Delete(Notes entity);
    }
}
