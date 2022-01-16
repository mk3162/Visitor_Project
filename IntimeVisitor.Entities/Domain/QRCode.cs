using IntimeVisitor.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Entities.Domain
{
  public  class QRCode: BaseEntity, IEntity
    {
        

       // [MaxLength(150)]
        public string  Detail { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime? StopDate { get; set; }
        public List<Visit> Visits { get; set; }
    }
}
