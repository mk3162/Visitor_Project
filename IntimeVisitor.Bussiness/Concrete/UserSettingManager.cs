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
    public class UserSettingManager : IUserSettingService
    {
        private IUserSettingDAL _userSettingDAL;
        public UserSettingManager(IUserSettingDAL userSettingDAL)
        {
            _userSettingDAL = userSettingDAL;
        }
        public UserSetting Add(UserSetting entity)
        {
            entity.CreatedDate = DateTime.Now;
            return _userSettingDAL.Add(entity);
        }

        public UserSetting Delete(Guid id)
        {
            var entity = _userSettingDAL.Get(x => x.Id == id);
            entity.IsDeleted = true;
            entity.DeletedDate = DateTime.Now;
            return _userSettingDAL.Delete(entity);
        }

        public UserSetting Get(Guid id)
        {
            return _userSettingDAL.Get(x => x.Id == id);
        }

        public IEnumerable<UserSetting> GetAllAsEnumerable()
        {
            return _userSettingDAL.GetAllAsEnumerable();
        }

        public List<UserSetting> GetAllAsList()
        {
            return _userSettingDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<UserSetting> GetAllAsQueryable()
        {
            return _userSettingDAL.GetAllAsQueryable();
        }

        public UserSetting Update(UserSetting entity)
        {
            entity.ModifiedDate = DateTime.Now;
            return _userSettingDAL.Update(entity);
        }
    }
}
