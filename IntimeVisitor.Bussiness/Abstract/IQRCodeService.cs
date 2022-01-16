using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
   public interface IQRCodeService
    {
        IQueryable<QRCode> GetAllAsQueryable();
        IEnumerable<QRCode> GetAllAsEnumerable();
        List<QRCode> GetAllAsList();

        QRCode Get(Guid id);

        QRCode Add(QRCode entity);
        QRCode Update(QRCode entity);
        QRCode Delete(Guid id);
    }
}
