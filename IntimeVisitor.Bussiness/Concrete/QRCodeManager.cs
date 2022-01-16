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
    public class QRCodeManager : IQRCodeService
    {
        private IQRCodeDAL _qRCodeDAL;
        public QRCodeManager(IQRCodeDAL qRCodeDAL)
        {
            _qRCodeDAL = qRCodeDAL;
        }
        public QRCode Add(QRCode entity)
        {
            entity.CreatedDate = DateTime.Now;
            return _qRCodeDAL.Add(entity);
        }

        public QRCode Delete(Guid id)
        {
            var entity = _qRCodeDAL.Get(x => x.Id == id);
            entity.DeletedDate = DateTime.Now;
            entity.IsDeleted = true;
            return _qRCodeDAL.Update(entity);
        }

        public QRCode Get(Guid id)
        {
            return _qRCodeDAL.Get(x => x.Id == id);
        }

        public IEnumerable<QRCode> GetAllAsEnumerable()
        {
            return _qRCodeDAL.GetAllAsEnumerable();
        }

        public List<QRCode> GetAllAsList()
        {
            return _qRCodeDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<QRCode> GetAllAsQueryable()
        {
            return _qRCodeDAL.GetAllAsQueryable();  
        }

        public QRCode Update(QRCode entity)
        {
            entity.ModifiedDate = DateTime.Now;
            return _qRCodeDAL.Update(entity);
        }
    }
}
