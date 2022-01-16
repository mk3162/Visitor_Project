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
    public class BranchTypeManager // : IBranchService
    {
        
        private readonly IBranchTpyeDAL _branchTypeDAL;
                         
        public BranchTypeManager( IBranchTpyeDAL branchTypeDAL)
        {
            
            _branchTypeDAL = branchTypeDAL;
        }

        //public BranchViewModel Fill(BranchViewModel model)
        //{
        //    var company = _companyDAL.GetAllAsList().Where(x => x.IsDeleted == false).Select(i => new SelectListItem
        //    {
        //        Text = i.CompanyName,
        //        Value = i.Id.ToString()
        //    }).ToList();
        //    var branchType = _branchTypeDAL.GetAllAsList().Where(x => x.IsDeleted == false).Select(i => new SelectListItem
        //    {
        //        Text = i.Name,
        //        Value = i.Id.ToString()
        //    }).ToList();
        //    model.Companies = company;
        //    model.BranchTypes = branchType;
        //    return model;
        //}
        public BranchType Add(BranchType entity)
        {
            return _branchTypeDAL.Add(entity);

        }

        public BranchType Delete(Guid id)
        {
            var branchType = _branchTypeDAL.Get(x => x.Id == id);
            branchType.IsDeleted = true;
            branchType.DeletedDate = DateTime.Now;

            return _branchTypeDAL.Update(branchType);
        }

        public BranchType Get(Guid id)
        {
            return _branchTypeDAL.Get(x => x.Id == id);
        }

        public IEnumerable<BranchType> GetAllAsEnumerable()
        {
            return _branchTypeDAL.GetAllAsEnumerable();
        }

        public List<BranchType> GetAllAsList()
        {
            return _branchTypeDAL.GetAllAsList(x => x.IsDeleted == false);
        }

        public IQueryable<BranchType> GetAllAsQueryable()
        {
            return _branchTypeDAL.GetAllAsQueryable();
        }



        public BranchType Update(BranchType entity)
        {
            entity.ModifiedDate = DateTime.Now;
            return _branchTypeDAL.Update(entity);
        }

        public IQueryable<BranchType> GetAll()
        {
            return _branchTypeDAL.GetAll();
        }
    }
}
