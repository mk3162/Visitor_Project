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
   public class UserRoles:BaseEntity,IEntity // Rol
    { 
       
      

        //[Required(ErrorMessage = "Lütfen Rol Adını Yazınız.")]
        //[MaxLength(30)]
        public string RolesName { get; set; }  // Rol Adı


        public string UsersIds { get; set; } // Kullanıcılar
        //[Required(ErrorMessage = "Lütfen Açıklama Yazınız.")]
        //[MaxLength(150)]
        public string Description { get; set; } // Açıklama

       

      

        
        public string PermisionsIds { get; set; } // Yetkiler

        public List<User> Users { get; set; }
    }
}
