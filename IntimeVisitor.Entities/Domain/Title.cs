using IntimeVisitor.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Entities.Domain
{
    public class Title:BaseEntity,IEntity
    {

       
      //  [Required(ErrorMessage = "Lütfen Başlık Adı Yazınız.")]
      //  [MaxLength(30)]
        public string TitleName { get; set; } // Unvan Adı

      //  [Required(ErrorMessage = "Lütfen Açıklama Yazınız.")]
      //  [MaxLength(150)]
        public string Description { get; set; } // Açıklama
        public List<User> Users { get; set; }
    }
}
