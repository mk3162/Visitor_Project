using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Entities.ViewModel.BranchVMs
{
  public  class BranchVMforListing
    {
        public Branch Branch { get; set; }
        public List< Branch> Branches { get; set; }
    }
}
