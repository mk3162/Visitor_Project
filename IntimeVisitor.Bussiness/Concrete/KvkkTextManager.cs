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
    public class KvkkTextManager : IKvkkTextService
    {
        private IKvkkTextDAL _kvkkTextDAL;
        public KvkkTextManager(IKvkkTextDAL kvkkTextDAL)
        {
            _kvkkTextDAL = kvkkTextDAL;
        }
        public KvkkText Add(KvkkText entity)
        {
            entity.Status = true;
            return _kvkkTextDAL.Add(entity);
        }

        public KvkkText Delete(Guid id)
        {
            var entity = _kvkkTextDAL.Get(x => x.Id == id);
            entity.IsDeleted = true;
            entity.DeletedDate = DateTime.Now;
            return _kvkkTextDAL.Update(entity);
        }

        public KvkkText Get(Guid id)
        {
            return _kvkkTextDAL.Get(x => x.Id == id);
        }

        public IEnumerable<KvkkText> GetAllAsEnumerable()
        {
            return _kvkkTextDAL.GetAllAsEnumerable();
        }

        public List<KvkkText> GetAllAsList()
        {
            return _kvkkTextDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<KvkkText> GetAllAsQueryable()
        {
            return _kvkkTextDAL.GetAllAsQueryable();
        }

        public KvkkText Update(KvkkText entity)
        {
            entity.ModifiedDate = DateTime.Now;
            return _kvkkTextDAL.Update(entity);
        }
    }
}
