using IntimeVisitor.Bussiness.Abstract;
using IntimeVisitor.DataAccess.Concrete;
using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Concrete
{
    public class MediaTypeManager : IMediaTypeService
    {
        private MediaTypeDAL _mediaTypeDAL;
        public MediaTypeManager(MediaTypeDAL mediaTypeDAL)
        {
            _mediaTypeDAL = mediaTypeDAL;
        }
        public MediaType Add(MediaType entity)
        {
            entity.CreatedDate = DateTime.Now;            
            return _mediaTypeDAL.Add(entity);
        }

        public MediaType Delete(Guid id)
        {
            var entity = _mediaTypeDAL.Get(x => x.Id == id);
            entity.IsDeleted = true;
            entity.DeletedDate = DateTime.Now;
            return _mediaTypeDAL.Update(entity);
        }

        public MediaType Get(Guid id)
        {
            return _mediaTypeDAL.Get(x => x.Id == id);
        }

        public IEnumerable<MediaType> GetAllAsEnumerable()
        {
            return _mediaTypeDAL.GetAllAsEnumerable();
        }

        public List<MediaType> GetAllAsList()
        {
            return _mediaTypeDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<MediaType> GetAllAsQueryable()
        {
            return _mediaTypeDAL.GetAllAsQueryable();
        }

        public MediaType Update(MediaType entity)
        {
            entity.ModifiedDate = DateTime.Now;
            return _mediaTypeDAL.Update(entity);
        }
    }
}
