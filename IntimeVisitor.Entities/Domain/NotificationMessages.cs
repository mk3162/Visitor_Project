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
    public  class NotificationMessages:BaseEntity,IEntity
    {
        


        //[Required(ErrorMessage = "Lütfen Bildirim Adını Yazınız.")]
        [StringLength(50)]
        public string MessageName { get; set; }

       // [Required(ErrorMessage = "Lütfen Bildirim Detay Yazınız.")]
        [StringLength(500)]
        public string MessageDetails { get; set; }


        public List<NotificationSend> NotificationSends { get; set; }
    }
}
