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
    public class CompanyManager : ICompanyService
    {
        private ICompanyDAL _companyDAL;
        public CompanyManager(ICompanyDAL companyDAL)
        {
            _companyDAL = companyDAL;
        }
        public Company Add(Company entity)
        {
            return _companyDAL.Add(entity);
        }

        public Company Delete(Guid id)
        {
            var entity = _companyDAL.Get(x => x.Id == id);
            entity.DeletedDate = DateTime.Now;
            entity.IsDeleted = true;
            return _companyDAL.Update(entity);
        }

        public Company Get(Guid id)
        {
            return _companyDAL.Get(x => x.Id == id);
        }

        public IEnumerable<Company> GetAllAsEnumerable()
        {
            return _companyDAL.GetAllAsEnumerable();
        }

        public List<Company> GetAllAsList()
        {
            return _companyDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<Company> GetAllAsQueryable()
        {
            return _companyDAL.GetAllAsQueryable();
        }

        public Company Update(Company entity)
        {
            entity.ModifiedDate = DateTime.Now;
            return _companyDAL.Update(entity);
        }
    }
}
