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
   public class MediaType:BaseEntity,IEntity // Media Tipi
    {
       

   

        //[Required(ErrorMessage = "Lütfen Medya Adını Yazınız .")]
        [StringLength(30)]
        public string MediaTypeName { get; set; } // Media Tipi

        [Column(TypeName ="Bit")]
        public bool? Status { get; set; } // Durum
        public List<Media> Medias { get; set; }
    }
}
