using IntimeVisitor.Bussiness.Abstract;
using IntimeVisitor.DataAccess.Abstract;
using IntimeVisitor.DataAccess.Concrete;
using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Concrete
{
    public class NotesManager : INotesService
    {
        private INotesDAL _notesDAL;
        public NotesManager(INotesDAL notesDAL)
        {
            _notesDAL = notesDAL;
        }
        public Notes Add(Notes entity)
        {
            return _notesDAL.Add(entity);
        }

        public Notes Delete(Notes entity)
        {
            throw new NotImplementedException();
        }

        public Notes Get(Guid id)
        {
            return _notesDAL.Get(x => x.Id == id);
        }

        public IEnumerable<Notes> GetAllAsEnumerable()
        {
            return _notesDAL.GetAllAsEnumerable();
        }

        public List<Notes> GetAllAsList()
        {
            return _notesDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<Notes> GetAllAsQueryable()
        {
            return _notesDAL.GetAllAsQueryable();
        }

        public Notes Update(Notes entity)
        {
            entity.ModifiedDate = DateTime.Now;
            return _notesDAL.Update(entity);
            
        }
    }
}
