using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
   public interface INotificationMessagesService
    {

        IQueryable<NotificationMessages> GetAllAsQueryable();
        IEnumerable<NotificationMessages> GetAllAsEnumerable();
        List<NotificationMessages> GetAllAsList();

        NotificationMessages Get(Guid id);

        NotificationMessages Add(NotificationMessages entity);
        NotificationMessages Update(NotificationMessages entity);
        NotificationMessages Delete(Guid id);
    }
}
