using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
   public interface IKvkkTextService
    {
        IQueryable<KvkkText> GetAllAsQueryable();
        IEnumerable<KvkkText> GetAllAsEnumerable();
        List<KvkkText> GetAllAsList();

        KvkkText Get(Guid id);

        KvkkText Add(KvkkText entity);
        KvkkText Update(KvkkText entity);
        KvkkText Delete(Guid id);
    }
}
