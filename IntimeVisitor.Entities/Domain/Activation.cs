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
    public class Activation:BaseEntity,IEntity
    {
        
        //User Tablosu İle Baglantısı Yapılacak
        public Guid? UserId { get; set; } // User Id 

        [Column(TypeName = "DateTime2")]
        public DateTime? ExpireDate { get; set; }

        
        public Guid? NotifiactionTypeId { get; set; }
        public NotificationTypeArchive  NotificationTypeArchive { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime NotifiactionDate { get; set; }
    }
}
