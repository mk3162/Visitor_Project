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
    public class ClarificationTextManager : IClarificationTextService
    {
        private IClarificationTextDAL _clarificationTextDAL;
        public ClarificationTextManager(IClarificationTextDAL clarificationTextDAL)
        {
            _clarificationTextDAL = clarificationTextDAL;
        }
        public ClarificationText Add(ClarificationText entity)
        {
            entity.Status = true;
            return _clarificationTextDAL.Add(entity);
        }

        public ClarificationText Delete(Guid id)
        {
            var entity = _clarificationTextDAL.Get(x => x.Id == id);
            entity.IsDeleted = true;
            entity.DeletedDate = DateTime.Now;
            return _clarificationTextDAL.Update(entity);
        }

        public ClarificationText Get(Guid id)
        {
            return _clarificationTextDAL.Get(x => x.Id == id);
        }

        public IEnumerable<ClarificationText> GetAllAsEnumerable()
        {
            return _clarificationTextDAL.GetAllAsEnumerable();
        }

        public List<ClarificationText> GetAllAsList()
        {
            return _clarificationTextDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<ClarificationText> GetAllAsQueryable()
        {
            return _clarificationTextDAL.GetAllAsQueryable();
        }

        public ClarificationText Update(ClarificationText entity)
        {
            throw new NotImplementedException();
        }
    }
}
