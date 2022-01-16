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
    public class NotificationSendManager : INotificationSendService
    {
        private INotificationSendDAL _notificationSendDAL;
        public NotificationSendManager(INotificationSendDAL notificationSendDAL)
        {
            _notificationSendDAL = notificationSendDAL;
        }
        public NotificationSend Add(NotificationSend entity)
        {
            entity.CreatedDate = DateTime.Now;
            return _notificationSendDAL.Add(entity);
        }

        public NotificationSend Delete(Guid id)
        {
            var entity = _notificationSendDAL.Get(x => x.Id == id);
            entity.DeletedDate = DateTime.Now;
            entity.IsDeleted = true;
            return _notificationSendDAL.Update(entity);
        }

        public NotificationSend Get(Guid id)
        {
            return _notificationSendDAL.Get(x => x.Id == id);
        }

        public IEnumerable<NotificationSend> GetAllAsEnumerable()
        {
            return _notificationSendDAL.GetAllAsEnumerable();
        }

        public List<NotificationSend> GetAllAsList()
        {
            return _notificationSendDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<NotificationSend> GetAllAsQueryable()
        {
            return _notificationSendDAL.GetAllAsQueryable();
        }

        public NotificationSend Update(NotificationSend entity)
        {
            entity.ModifiedDate = DateTime.Now;
            return _notificationSendDAL.Update(entity);
        }
    }
}
