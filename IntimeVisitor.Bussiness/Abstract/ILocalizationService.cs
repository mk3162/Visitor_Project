using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
 public   interface ILocalizationService
    {
        IQueryable<LocalizationStrings> GetAllAsQueryable();
        IEnumerable<LocalizationStrings> GetAllAsEnumerable();
        List<LocalizationStrings> GetAllAsList();

        LocalizationStrings Get(Guid id);

        LocalizationStrings Add(LocalizationStrings entity);
        LocalizationStrings Update(LocalizationStrings entity);
        LocalizationStrings Delete(LocalizationStrings entity);
    }
}
