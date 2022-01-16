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
    public class CompanyTypeManager : ICompanyTypeService
    {
        private ICompanyTypeDAL _companyTypeDAL;
        public CompanyTypeManager(ICompanyTypeDAL companyTypeDAL)
        {
            _companyTypeDAL = companyTypeDAL;
        }
        public CompanyType Add(CompanyType entity)
        {
            entity.Status = true;
            return _companyTypeDAL.Add(entity);
        }

        public CompanyType Delete(Guid id)
        {
            var entity = _companyTypeDAL.Get(x => x.Id == id);
            entity.DeletedDate = DateTime.Now;
            entity.IsDeleted = true;
            return _companyTypeDAL.Update(entity);
        }

        public CompanyType Get(Guid id)
        {
            return _companyTypeDAL.Get(x => x.Id == id);
        }

        public IEnumerable<CompanyType> GetAllAsEnumerable()
        {
            return _companyTypeDAL.GetAllAsEnumerable();
        }

        public List<CompanyType> GetAllAsList()
        {
            return _companyTypeDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<CompanyType> GetAllAsQueryable()
        {
            return _companyTypeDAL.GetAllAsQueryable();
        }

        public CompanyType Update(CompanyType entity)
        {
            entity.ModifiedDate = DateTime.Now;
            return _companyTypeDAL.Update(entity);
        }
    }
}
