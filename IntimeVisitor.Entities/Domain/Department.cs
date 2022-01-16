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
   public class Department:BaseEntity,IEntity // Departman
    {
       

        //[Required(ErrorMessage = "Lütfen Departman Adını Yazınız.")]
        [StringLength(30)]
        public string DepartmentName { get; set; } // Departman İsmi

        //[Required(ErrorMessage = "Lütfen Şube  Seçiniz.")]
        //Şube İle Bağlantısı Yapılacak
        public Guid? BranchId { get; set; } // Şube 
        public virtual Branch Branch { get; set; }





        [InverseProperty("Department")]
        public List<VisitPoint> VisitPoints { get; set; }
    }
}
