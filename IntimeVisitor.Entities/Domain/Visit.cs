using IntimeVisitor.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Entities.Domain
{
 public   class Visit:BaseEntity,IEntity // Ziyaret
    {




        //public Guid? VisitDetailId { get; set; } // Ziyaret Detay Id
        //public virtual VisitDetail VisitDetail { get; set; }
        public Guid? QRCodeId { get; set; } //QRKodu

        public virtual QRCode QRCode  { get; set; }
        //[Required(ErrorMessage = "Lütfen Ziyaretçi Adını Seçiniz.")]

        public string VisitNotes { get; set; } //Ziyaret Gerçekleşme Notu

        public Guid? UserId { get; set; } // Kullanıcı Id
        public virtual User User { get; set; }
        public List<VisitDetail> VisitDetails { get; set; }
    }
}
