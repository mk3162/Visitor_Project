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
  public  class UserType:BaseEntity,IEntity // Kullanıcı Tipi
    {
        
        //[MaxLength(30)]
        //[Required(ErrorMessage = "Lütfen Kullanıcı Tip Adını Yazınız.")]
        public string UserTypeName { get; set; } // User Tip İsmi
        //[Column(TypeName ="Bit")]
        public bool? Status { get; set; } // Kullanım 
        public List<User> Users { get; set; }
    }
}
