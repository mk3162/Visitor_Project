using IntimeVisitor.Core.Entities;
using IntimeVisitor.Entities.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Entities.ViewModel.Calendar
{
    public class AppointmentViewModel : BaseEntity, IEntity
    {


        public DateTime PlanStartDate { get; set; } // Planlanan Başlama tarihi


        public DateTime PlanStartTime { get; set; } // Planlanan Başlama Saati


        public DateTime PlanEndDate { get; set; } // Planlanan Bitiş Tarihi


        public DateTime PlanEndTime { get; set; } // Planlanan Bitiş Saati
        public Guid VisitId { get; set; } // Ziyaret Id

        //TODO: Birkaç ziyaret noktası ziyaret edilebilir.

        public Guid VisitPointId { get; set; } // Ziyaret Noktası Id



        public Guid UserId { get; set; } // Kullanıcı Bilgisi Id




        public Guid LastVisitDetailId { get; set; } // Bir sonraki Ziyaret Detayı Id Si
                                                    //  Ömere Sor
                                                    //public List<Visit> Visits { get; set; }

        public Guid Visit_UserId { get; set; } // Kullanıcı Bilgisi Id

        public string VisitStatus { get; set; } // Ziyaret Durumu

        public bool AllDay { get; set; } // Calendar İçin eklendi
        public string IsApproved { get; set; } // Onay Durumu



        public string AttendiesIds { get; set; }


    }
}
