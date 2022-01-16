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
    public class NotificationTypeArchiveManager : INotificationTypeArchiveService
    {
        private INotificationTypeArchiveDAL _notificationTypeArchiveDAL;
        public NotificationTypeArchiveManager(INotificationTypeArchiveDAL notificationTypeArchiveDAL)
        {
            _notificationTypeArchiveDAL = notificationTypeArchiveDAL;
        }
        public NotificationTypeArchive Add(NotificationTypeArchive entity)
        {
            entity.CreatedDate = DateTime.Now;
            return _notificationTypeArchiveDAL.Add(entity);
        }

        public NotificationTypeArchive Delete(Guid id)
        {
            var entity = _notificationTypeArchiveDAL.Get(x => x.Id == id);
            entity.IsDeleted = true;
            entity.DeletedDate = DateTime.Now;
            return _notificationTypeArchiveDAL.Update(entity);
        }

        public NotificationTypeArchive Get(Guid id)
        {
            return _notificationTypeArchiveDAL.Get(x => x.Id == id);
        }

        public IEnumerable<NotificationTypeArchive> GetAllAsEnumerable()
        {
            return _notificationTypeArchiveDAL.GetAllAsEnumerable();
        }

        public List<NotificationTypeArchive> GetAllAsList()
        {
            return _notificationTypeArchiveDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<NotificationTypeArchive> GetAllAsQueryable()
        {
            return _notificationTypeArchiveDAL.GetAllAsQueryable();
        }

        public NotificationTypeArchive Update(NotificationTypeArchive entity)
        {
            entity.ModifiedDate = DateTime.Now;
            return _notificationTypeArchiveDAL.Update(entity);
        }
    }
}
