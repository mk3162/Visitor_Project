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
    public class NotificationSend:BaseEntity,IEntity
    {
        //[Required(ErrorMessage = "Lütfen  Kullanıcı Seçiniz.")]
        //User Tablosu İle Bağlantısı Yapılacak
        public Guid? UserId { get; set; }
        public virtual User User { get; set; }

       // [Required(ErrorMessage = "Lütfen İş Süreci Seçiniz.")]
        //İş akış tablosu ile bağlantsı yapılacak
        public Guid? WorkflowId { get; set; }

        public virtual Workflow Workflow { get; set; }

        [Column(TypeName ="Bit")]
        public bool? IsSend { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime SendDate { get; set; }

        //Bildirim Tipi TABLOSU iLE BAĞLANTISI YAPILACAK 
        public Guid? NotificationTypeId { get; set; }
        public virtual NotificationTypeArchive  NotificationTypeArchive { get; set; }


        //Mesaj TABLOSU iLE BAĞLANTISI YAPILACAK
        public Guid? NotificationMessageId { get; set; }
        public virtual NotificationMessages NotificationMessages { get; set; }


        public string ServerIp { get; set; }

    }
}
