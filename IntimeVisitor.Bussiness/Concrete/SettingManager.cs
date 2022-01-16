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
    public class SettingManager : ISettingService
    {
        private ISettingDAL _settingDAL;
        public SettingManager(ISettingDAL settingDAL)
        {
            _settingDAL = settingDAL;
        }
        public Setting Add(Setting entity)
        {
            entity.CreatedDate = DateTime.Now;
            return _settingDAL.Add(entity);
        }

        public Setting Delete(Guid id)
        {
            var entity = _settingDAL.Get(x => x.Id == id);
            entity.IsDeleted = true;
            entity.DeletedDate = DateTime.Now;
            return _settingDAL.Update(entity);
        }

        public Setting Get(Guid id)
        {
            return _settingDAL.Get(x => x.Id == id);
        }

        public IEnumerable<Setting> GetAllAsEnumerable()
        {
            return _settingDAL.GetAllAsEnumerable();
        }

        public List<Setting> GetAllAsList()
        {
            return _settingDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<Setting> GetAllAsQueryable()
        {
            return _settingDAL.GetAllAsQueryable();
        }

        public Setting Update(Setting entity)
        {
            entity.ModifiedDate = DateTime.Now;
            return _settingDAL.Update(entity);
        }
    }
}
