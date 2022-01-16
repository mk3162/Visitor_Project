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
    public class Branch : BaseEntity, IEntity // Şube Tablosu
    {


       // [Required(ErrorMessage = "Lütfen Firma Seçiniz.")]

        //Firma tablosu ile bağlantısı yapılacak
        public Guid? CompanyId { get; set; } // Şirket Id
        public virtual Company Company { get; set; }


        //[Required(ErrorMessage = "Lütfen Şube Tipi Seçiniz.")]
        //Şube Tip Tablosu İle Bağlantısı Yapılacak
        public Guid? BranchTypeId { get; set; } // Şube Tipi

        public virtual BranchType BranchType { get; set; }

        //[Required(ErrorMessage = "Lütfen Şube Adı Yazınız.")]
        [StringLength(30)]
        public string BranchName { get; set; }  // Şube Adı

        //Adres Tablosu İle Bağlantısı Yapılacak
        //[Required(ErrorMessage = "Lütfen Şube Adresini Seçiniz.")]
        public Guid? AddressId { get; set; } // Adres 
        public virtual Address Address { get; set; }

        //[Required(ErrorMessage = "Lütfen Şube Telefon Yazınız.")]

        [StringLength(11)]
        public string BranchPhoneNumber { get; set; } // Şube Telefon No

       // [Required(ErrorMessage = "Lütfen Şube E-Mail Bilgilerini")]
        [StringLength(100)]
        public string BranchEMail { get; set; } // Şube EMail



        public string Location { get; set; } // Lokasyon

        public List<Department> Departments { get; set; }
    }
}
