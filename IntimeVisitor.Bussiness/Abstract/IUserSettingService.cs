using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
   public interface IUserSettingService
    {
        IQueryable<UserSetting> GetAllAsQueryable();
        IEnumerable<UserSetting> GetAllAsEnumerable();
        List<UserSetting> GetAllAsList();

        UserSetting Get(Guid id);

        UserSetting Add(UserSetting entity);
        UserSetting Update(UserSetting entity);
        UserSetting Delete(Guid id);
    }
}
