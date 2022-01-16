using IntimeVisitor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Entities.Domain
{
   public class ClarificationText :BaseEntity,IEntity
    {

        
        public string Text { get; set; } // Aydınlatma Metni içeriği
        public Guid? CompanyId { get; set; } // Firma 
        public virtual Company Company { get; set; }

        public bool? Status { get; set; } // Kullanım
    }
}
