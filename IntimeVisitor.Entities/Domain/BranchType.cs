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
   public class BranchType :BaseEntity,IEntity // Şube Tipi
    {
      

        //[Required(ErrorMessage = "Lütfen Şube Tipi  Adınız Yazınız.")]
        [StringLength(30)]
        public string BranchTypeName { get; set; } // Şube Tip Adı
        
        [Column(TypeName ="Bit")]
        public bool? Status { get; set; } // Durum
        public List<Branch> Branches{ get; set; }
    }
}
