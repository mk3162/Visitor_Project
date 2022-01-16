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
  public  class NotificationTypeArchive:BaseEntity,IEntity
    {
        

       

        //[Required(ErrorMessage = "Lütfen İş Süreç Tip Adını Seçiniz.")]
        [MaxLength(30)]      
        public string NotificationTypeName { get; set; }

       // [Required(ErrorMessage = "Lütfen Server Bilgilerini Yazını.")]
        [MaxLength(30)]
        public string ServerDescription { get; set; }
        [MaxLength(30)]
        public string ServerInfo { get; set; }
        public List<Activation> Activations { get; set; }
        public List<NotificationSend> NotificationSends { get; set; }
    }
}
