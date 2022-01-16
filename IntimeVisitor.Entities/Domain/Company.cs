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
    public class Company :BaseEntity,IEntity// Şirket
    {
       
      

        //[Required(ErrorMessage = "Lütfen Firma Adını Yazınız.")]
        [StringLength(30)]
        public string Name { get; set; } // İsim

        //Firma Tip tablosu ile bağlantısı yapılacak 
        //[Required(ErrorMessage = "Lütfen Firma Tipi Seçiniz.")]
        public Guid? CompanyTypeId { get; set; } // Şirket Tipi
        public virtual CompanyType CompanyType { get; set; }

        //[Required(ErrorMessage = "Lütfen Firma Ünvan Yazınız.")]
        [StringLength(100)]
        public string Title { get; set; } // Unvan


        //[Required(ErrorMessage = "Lütfen Vergi Dairesi Yazınız.")]
        [StringLength(100)]
        public string TaxAdministration { get; set; } // Vergi Dairesi

        //[Required(ErrorMessage = "Lütfen Vergi No Yazınız.")]
        [StringLength(50)]
        public string TaxNo { get; set; } // Vergi No

        //[Required(ErrorMessage = "Lütfen Telefon Numarasını Yazınız.")]
        [StringLength(11)]
        public string Phone { get; set; } // Telefon No

        //[Required(ErrorMessage = "Lütfen Fax Numarasını Yazınız.")]
        [StringLength(11)]
        public string Fax { get; set; } // Fax No 
        //[Required(ErrorMessage = "Lütfen Adres  Seçiniz.")]
        //Adres Tablosu ile Bağlantısı Yapılacak
        public Guid? AddressId { get; set; } // Addres Id Bilgisi
        public virtual Address Address { get; set; }


        //[Required(ErrorMessage = "Lütfen EMail Adresini Yazınız .")]
        [StringLength(100)]
        public string EMail { get; set; } // Email Adresi

        //[Required(ErrorMessage = "Lütfen EMail KEP Adresini Yazınız .")]
        [StringLength(100)]
        public string EMailKEP { get; set; } // Kayıtlı Eposta Adresi (Kep)


        public List<Branch> Branches { get; set; }
        public List<User> Users { get; set; }
        public List<ClarificationText> ClarificationTexts { get; set; }
        public List<KvkkText> KvkkTexts { get; set; }

        public string CompanyImageFile { get; set; }
   


    }
}
