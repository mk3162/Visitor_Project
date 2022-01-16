using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Bussiness.Abstract
{
    public interface IAddressService
    {
        IQueryable<Address> GetAllAsQueryable();
        IEnumerable<Address> GetAllAsEnumerable();
        List<Address> GetAllAsList();

        Address Get(Guid id);

        Address Add(Address entity);
        Address Update(Address entity);
        Address Delete(Guid id);
    }
}
