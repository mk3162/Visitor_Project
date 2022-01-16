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
    public class VisitPoint : BaseEntity, IEntity // Ziyaret Noktası 
    {



        //[Required(ErrorMessage = "Lütfen Ziyaret Noktası Adı Yazınız.")]
        //[StringLength(30)]
        public string VisitPointName { get; set; } // Ziyaret Noktası İsmi

        //[Required(ErrorMessage = "Lütfen Departman Seçiniz.")]
        //Departman İle Bağlantı
        public Guid? DepartmantId { get; set; } // Departman Id
        [ForeignKey("DepartmantId")]
        public virtual Department Department { get; set; }
     
        public  List<VisitDetail> VisitDetails { get; set; }
        public string Color { get; set; }
        // public ICollection<Department> Departments { get; set; } 
        public int? Capacity { get; set; }
    }
}
