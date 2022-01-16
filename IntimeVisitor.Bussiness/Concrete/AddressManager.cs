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
    public class AddressManager : IAddressService
    {
        //TODO: Managerler içerisinde Dalı çağırırken private injection yapılacak
        public IAddressDAL _addressDAL { get; set; }
        public AddressManager(IAddressDAL addressDAL)
        {
            _addressDAL = addressDAL;
        }
        public Address Add(Address entity)
        {
            return _addressDAL.Add(entity);
        }

        public Address Delete(Guid id)
        {
            var entity = _addressDAL.Get(x => x.Id == id);
            entity.IsDeleted = true;
            entity.DeletedDate = DateTime.Now;
            return _addressDAL.Update(entity);
        }

        public Address Get(Guid id)
        {
            return _addressDAL.Get(x => x.Id == id);
        }

        public IEnumerable<Address> GetAllAsEnumerable()
        {
            return _addressDAL.GetAllAsEnumerable();
        }

        public List<Address> GetAllAsList()
        {
            return _addressDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<Address> GetAllAsQueryable()
        {
            return _addressDAL.GetAllAsQueryable();
        }

        public Address Update(Address entity)
        {
            entity.ModifiedDate = DateTime.Now;   
            return _addressDAL.Update(entity);
        }
    }
}
