using IntimeVisitor.Core.DataAccess.Abstract;
using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.DataAccess.Abstract
{
    public interface ICompanyTypeDAL : IRepository<CompanyType, IntimeVisitor.Entities.Context.IntimeVisitorContext>
    {


    }
}
