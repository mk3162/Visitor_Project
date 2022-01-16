using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
  public  interface IMediaService
    {
        IQueryable<Media> GetAllAsQueryable();
        IEnumerable<Media> GetAllAsEnumerable();
        List<Media> GetAllAsList();

        Media Get(Guid id);

        Media Add(Media entity);
        Media Update(Media entity);
        Media Delete(Guid id);
    }
}
