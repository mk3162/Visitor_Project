using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
   public interface IClarificationTextService
    {
        IQueryable<ClarificationText> GetAllAsQueryable();
        IEnumerable<ClarificationText> GetAllAsEnumerable();
        List<ClarificationText> GetAllAsList();

        ClarificationText Get(Guid id);

        ClarificationText Add(ClarificationText entity);
        ClarificationText Update(ClarificationText entity);
        ClarificationText Delete(Guid id);
    }
}
