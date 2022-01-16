using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
    public interface ISettingService
    {
        IQueryable<Setting> GetAllAsQueryable();
        IEnumerable<Setting> GetAllAsEnumerable();
        List<Setting> GetAllAsList();

        Setting Get(Guid id);

        Setting Add(Setting entity);
        Setting Update(Setting entity);
        Setting Delete(Guid id);
    }
}
