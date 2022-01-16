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
  public  class Permision :BaseEntity, IEntity// Yetki
    {   
       // [MaxLength(30)]
       // [Required(ErrorMessage = "Lütfen İzin Adını Yazınız.")]
        public string Name { get; set; } // Permision Name
       // [MaxLength(150)]

      //  [Required(ErrorMessage = "Lütfen Açıklama Yazınız.")]
        public string Description { get; set; } // Açıklama  
    }
}
