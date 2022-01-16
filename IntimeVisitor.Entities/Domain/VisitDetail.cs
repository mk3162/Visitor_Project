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
    public class VisitDetail:BaseEntity,IEntity // Ziyaret Detay 
    {
      

        [Required(ErrorMessage = "Lütfen Ziyaret Başlama Tarihini Seçiniz.")]
        [Column(TypeName = "DateTime2")]
        public DateTime PlanStartDate { get; set; } // Başlama tarihi

        [Required(ErrorMessage = "Lütfen Ziyaretçi Başlama Saatini Seçiniz.")]
        public DateTime PlanStartTime { get; set; } // Başlama Saati

        [Required(ErrorMessage = "Lütfen Ziyaret Bitiş Tarihini Seçiniz.")]
        [Column(TypeName = "DateTime2")]
        public DateTime  PlanEndDate { get; set; } // Başlama Tarihi

        [Required(ErrorMessage = "Lütfen Ziyaret Bitiş Saatini Seçiniz.")]
        public DateTime  PlanEndTime { get; set; } // Bitiş Saati
        public Guid? VisitId { get; set; } // Ziyaret Id
        public virtual Visit Visit { get; set; }

        //TODO: Birkaç ziyaret noktası ziyaret edilebilir.
        [Required(ErrorMessage = "Lütfen Ziyaret Noktasını Seçiniz.")]
        public Guid? VisitPointId { get; set; } // Ziyaret Noktası Id
        public virtual VisitPoint  VisitPoint { get; set; }


        public Guid? UserId { get; set; } // Kullanıcı Bilgisi Id
        public virtual User User { get; set; }

        //public List<User> Users { get; set; }

        public Guid? LastVisitDetailId { get; set; } // Bir sonraki Ziyaret Detayı Id Si
                                                     //  Ömere Sor
                                                     //public List<Visit> Visits { get; set; }

        public Guid? Visit_UserId { get; set; } // Kullanıcı Bilgisi Id
       
        public string VisitStatus { get; set; } // Ziyaret Durumu
        public List<Notes> Notes { get; set; }
        public bool? AllDay { get; set; } // Calendar İçin eklendi
        public string IsApproved{ get; set; } // Onay Durumu

        //ziyareti kabul eden katılımcıların id leri
        [Display(Name = "Attendies")]
        public string AttendiesIds { get; set; }


    }
}
