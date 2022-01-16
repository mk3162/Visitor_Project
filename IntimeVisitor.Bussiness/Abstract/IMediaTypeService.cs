using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
   public interface IMediaTypeService
    {
        IQueryable<MediaType> GetAllAsQueryable();
        IEnumerable<MediaType> GetAllAsEnumerable();
        List<MediaType> GetAllAsList();

        MediaType Get(Guid id);

        MediaType Add(MediaType entity);
        MediaType Update(MediaType entity);
        MediaType Delete(Guid id);
    }
}
