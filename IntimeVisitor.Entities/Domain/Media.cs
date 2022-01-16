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
    public class Media :BaseEntity,IEntity// MEDİA
    {
       


        //[Required(ErrorMessage = "Lütfen Dosya Yolunu Kontrol Ediniz.")]
        public string FilePath { get; set; } // Dosya Yolu

        //[Required(ErrorMessage = "Lütfen Medya Tipi Seçiniz.")]
        //Media Tipi Tablosu İle Bağlantısı Yapılacak
        public Guid? MediaTypeId { get; set; } // Media Tipi
        public virtual MediaType MediaType { get; set; }

        //[Required(ErrorMessage = "Lütfen Medya Açıklaması Yazınız.")]
        [StringLength(150)]
        public string Extension { get; set; } // Açıklama
       
      

        public List<User> Users { get; set; }
    }
}
