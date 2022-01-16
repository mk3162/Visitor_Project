using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Entities.ViewModel
{
    public class VMVisitDetailAdd
    {
        public Visit visit { get; set; }
        public VisitDetail visitDetail { get; set; }
        public Guid[] attendiesArray { get; set; }
    }
}
