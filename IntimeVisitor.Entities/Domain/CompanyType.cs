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
  public  class CompanyType:BaseEntity,IEntity // Şirket Tipi
    {
       

       // [Required(ErrorMessage = "Lütfen Firma  Tipi Yazınız.")]
        [StringLength(30)]

        public string CompanyTypeName { get; set; } // Şirket Tip İsmi

        [Column(TypeName = "Bit")]
        
        public bool?  Status { get; set; } // Durum
        public List<Company> Companies { get; set; }
    }
}
