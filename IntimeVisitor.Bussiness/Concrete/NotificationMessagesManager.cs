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
    public class NotificationMessagesManager : INotificationMessagesService
    {
        private INotificationMessagesDAL _notificationMessagesDAL;
        public NotificationMessagesManager(INotificationMessagesDAL notificationMessagesDAL)
        {
            _notificationMessagesDAL = notificationMessagesDAL;
        }
        public NotificationMessages Add(NotificationMessages entity)
        {
            entity.CreatedDate = DateTime.Now;
            return _notificationMessagesDAL.Add(entity);
        }

        public NotificationMessages Delete(Guid id)
        {
            var entity = _notificationMessagesDAL.Get(x => x.Id == id);
            entity.IsDeleted = true;
            entity.DeletedDate = DateTime.Now;
            return _notificationMessagesDAL.Update(entity);
        }

        public NotificationMessages Get(Guid id)
        {
            return _notificationMessagesDAL.Get(x => x.Id == id); 
        }

        public IEnumerable<NotificationMessages> GetAllAsEnumerable()
        {
            return _notificationMessagesDAL.GetAllAsEnumerable();
        }

        public List<NotificationMessages> GetAllAsList()
        {
            return _notificationMessagesDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<NotificationMessages> GetAllAsQueryable()
        {
            return _notificationMessagesDAL.GetAllAsQueryable();
        }

        public NotificationMessages Update(NotificationMessages entity)
        {
            entity.ModifiedDate = DateTime.Now;
            return _notificationMessagesDAL.Update(entity);
        }
    }
}
