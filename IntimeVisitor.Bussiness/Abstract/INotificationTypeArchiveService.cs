using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
   public interface INotificationTypeArchiveService
    {
        IQueryable<NotificationTypeArchive> GetAllAsQueryable();
        IEnumerable<NotificationTypeArchive> GetAllAsEnumerable();
        List<NotificationTypeArchive> GetAllAsList();

        NotificationTypeArchive Get(Guid id);

        NotificationTypeArchive Add(NotificationTypeArchive entity);
        NotificationTypeArchive Update(NotificationTypeArchive entity);
        NotificationTypeArchive Delete(Guid id);
    }
}
