using IntimeVisitor.Core.Entities;
using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntimeVisitor.WebUI.Models
{
    public class AddOrUpdateAppointmentModel: BaseEntity, IEntity
    {        
            [Required(ErrorMessage = "Lütfen Ziyaret Başlama Tarihini Seçiniz.")]
            [Column(TypeName = "DateTime2")]
            public DateTime PlanStartDate { get; internal set; } // Başlama tarihi

            [Required(ErrorMessage = "Lütfen Ziyaretçi Başlama Saatini Seçiniz.")]
            public DateTime PlanStartTime { get; internal set; } // Başlama Saati

            [Required(ErrorMessage = "Lütfen Ziyaret Bitiş Tarihini Seçiniz.")]
            [Column(TypeName = "DateTime2")]
            public DateTime PlanEndDate { get; internal set; } // Bitiş Tarihi

            [Required(ErrorMessage = "Lütfen Ziyaret Bitiş Saatini Seçiniz.")]
            public DateTime PlanEndTime { get; internal set; } // Bitiş Saati
            public Guid? VisitId { get; internal set; } // Ziyaret Id
            public virtual Visit Visit { get; internal set; }

            //TODO: Birkaç ziyaret noktası ziyaret edilebilir.
            [Required(ErrorMessage = "Lütfen Ziyaret Noktasını Seçiniz.")]
            public Guid? VisitPointId { get; internal set; } // Ziyaret Noktası Id
            public virtual VisitPoint VisitPoint { get; internal set; }


            public Guid? UserId { get; internal set; } // Kullanıcı Bilgisi Id
            public virtual User User { get; internal set; }

            //public List<User> Users { get; set; }

            public Guid? LastVisitDetailId { get; internal set; } // Bir sonraki Ziyaret Detayı Id Si
                                                         //public List<Visit> Visits { get; set; }

            public Guid? Visit_UserId { get; internal set; } // Kullanıcı Bilgisi Id

            public string VisitStatus { get; internal set; } // Ziyaret Durumu
            public List<Notes> Notes { get; internal set; }
            public bool? AllDay { get; internal set; } // Calendar İçin eklendi
            public string IsApproved { get; internal set; } // Onay Durumu

            //ziyareti kabul eden katılımcıların id leri
            [Display(Name = "Attendies")]
            public string AttendiesIds { get; internal set; }
    }
}