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
    public class Address : BaseEntity,IEntity
    {
       
        ////[Required(ErrorMessage = "Lütfen Ülke Yazınız.")]
        [StringLength(30)]
        public string Country { get; set; } // ÜLKE

        ////[Required(ErrorMessage = "Lütfen Şehir Yazınız.")]
        [StringLength(30)]
        public string City { get; set; } // Şehir

        //[Required(ErrorMessage = "Lütfen Semt / İlçe  Yazınız.")]
        [StringLength(30)]
        public string District { get; set; } // İlçe

        //[Required(ErrorMessage = "Lütfen Posta Kodu Yazınız.")]
        [StringLength(15)]
        public string PostalCode { get; set; } // Posta Kodu


        public string Openaddress { get; set; }

        public string AdressLocation { get; set; }



      
        public List<Branch> Branches { get; set; }
        public List<Company> Companies { get; set; }
        //public List<User> Users { get; set; }

    }
}
