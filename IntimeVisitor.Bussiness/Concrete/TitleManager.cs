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
    public class TitleManager : ITitleService
    {
        private ITitleDAL _titleDAL;
        public TitleManager(ITitleDAL titleDAL)
        {
            _titleDAL = titleDAL;
        }
        public Title Add(Title entity)
        {
            return _titleDAL.Add(entity);
        }

        public Title Delete(Guid id)
        {
            var entity = _titleDAL.Get(x => x.Id == id);
            entity.IsDeleted = true;
            entity.DeletedDate = DateTime.Now;
            return _titleDAL.Update(entity);
        }

        public Title Get(Guid id)
        {
            return _titleDAL.Get(x => x.Id == id);
        }

        public IEnumerable<Title> GetAllAsEnumerable()
        {
            return _titleDAL.GetAllAsEnumerable();
        }

        public List<Title> GetAllAsList()
        {
            return _titleDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<Title> GetAllAsQueryable()
        {
            return _titleDAL.GetAllAsQueryable();
        }

        public Title Update(Title entity)
        {
            entity.ModifiedDate = DateTime.Now;
            return _titleDAL.Update(entity);
        }
    }
}
