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
    public class Notes:BaseEntity,IEntity
    {
      


       // [Required(ErrorMessage = "Lütfen Note Adını Yazını.")]
        [StringLength(15)]
        public string NoteTitle { get; set; }

       // [Required(ErrorMessage = "Lütfen Note Detayını Yazınız.")]
        [MaxLength(300)]
        public string NoteDetails { get; set; }

        public Guid? VisitDetailId { get; set; } // Kullanıcı Bilgisi Id
        public virtual VisitDetail VisitDetail { get; set; }



    }
}
