using IntimeVisitor.Core.DataAccess.Concrete.EntityFramework;
using IntimeVisitor.DataAccess.Abstract;
using IntimeVisitor.Entities.Context;
using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.DataAccess.Concrete
{
    public class CompanyDAL : EntityFrameworkRepository<Company, IntimeVisitorContext>, ICompanyDAL
    {

    }
}
