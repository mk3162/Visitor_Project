using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Entities.ViewModel.VisitPoint
{
    public class VisitPointMeetingVM //TODO: isim değişikliği
    {
        public List<VisitDetail> visitDetails { get; set; }
        public List<string> visitPointNames { get; set; }
        public List<string> PointColor { get; set; }
    }
}
