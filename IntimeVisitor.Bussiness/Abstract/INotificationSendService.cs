using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
   public interface INotificationSendService
    {
        IQueryable<NotificationSend> GetAllAsQueryable();
        IEnumerable<NotificationSend> GetAllAsEnumerable();
        List<NotificationSend> GetAllAsList();

        NotificationSend Get(Guid id);

        NotificationSend Add(NotificationSend entity);
        NotificationSend Update(NotificationSend entity);
        NotificationSend Delete(Guid id);
    }
}
