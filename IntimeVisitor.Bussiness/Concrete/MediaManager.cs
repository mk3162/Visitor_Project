using IntimeVisitor.Bussiness.Abstract;
using IntimeVisitor.DataAccess.Abstract;
using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Concrete
{
    public class MediaManager : IMediaService
    {
        private IMediaDAL _mediaDAL;
        public MediaManager(IMediaDAL mediaDAL)
        {
            _mediaDAL = mediaDAL;
        }
        public Media Add(Media entity)
        {
            return _mediaDAL.Add(entity);
        }

        public Media Delete(Guid id)
        {
            var entity = _mediaDAL.Get(x => x.Id == id);
            entity.IsDeleted = true;
            entity.DeletedDate = DateTime.Now;
            return _mediaDAL.Update(entity);
        }

        public Media Get(Guid id)
        {
            return _mediaDAL.Get(x => x.Id == id);
        }

        public IEnumerable<Media> GetAllAsEnumerable()
        {
            return _mediaDAL.GetAllAsEnumerable();
        }

        public List<Media> GetAllAsList()
        {
            return _mediaDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<Media> GetAllAsQueryable()
        {
            return _mediaDAL.GetAllAsQueryable();
        }

        public Media Update(Media entity)
        {
            entity.ModifiedDate = DateTime.Now;
            return _mediaDAL.Update(entity);
        }
    }
}
