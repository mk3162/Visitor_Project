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
    public class User : BaseEntity, IEntity // Kullanıcı 
    {

       // [StringLength(30)]
        public string RegisterNo { get; set; } //sicil No

       // [Required(ErrorMessage = "Lütfen TC Kimlik No Yazınız.")]
       // [StringLength(11)]
        public string TCNo { get; set; } //Tc No


        //[Required(ErrorMessage = "Lütfen Kullanıcı Adını Yazınız.")]
       // [StringLength(30)]
        public string Name { get; set; } // İsim,

      //  [Required(ErrorMessage = "Lütfen Kullanıcı Soyadını Yazınız.")]
      //  [StringLength(30)]
        public string SurName { get; set; } // İsim

        //[Required(ErrorMessage = "Lütfen Kullanıcı Anne Adı  Yazınız.")]
      //  [StringLength(30)]
        public string FatherName { get; set; } // BabaAdı


      //  [StringLength(30)]
        public string MotherName { get; set; } //AnneAdı


        public bool? Gender { get; set; } // Cinsiyet



        public string BirthPlace { get; set; } // Doğum Yeri

        public string BirthDate { get; set; } // Doğum Tarihi



        public string Address { get; set; } // Adres 

        public string EPosta { get; set; }
        public string EPostaKep { get; set; }
        public string Phone { get; set; }

       // [StringLength(30)]
        public string Password { get; set; } // Şifre





       // [Required(ErrorMessage = "Lütfen Kullanıcı Tipini Seçiniz.")]
        //UserType Id Ye Bağlanacak
        public Guid? UserTypeId { get; set; } // UserType Id 
        public virtual UserType UserType { get; set; }


        //[StringLength(30)]
        public string UserName { get; set; }  // Kullanıcı Adı




        public bool Status { get; set; } // Rezervasyon Onaylanmış mı? Onaylanmamış mı?


        public bool IsDeleted { get; set; }

        // Role Tablosu İle Bağla 
        public Guid? RoleId { get; set; } //Role Id 
        public virtual UserRoles Roles { get; set; }

        [StringLength(30)]
        public string PlateNo { get; set; }

        // Title Tablosu İle Bağla 
        public Guid? TitleId { get; set; } // Unvan 
        public virtual Title Title { get; set; }

        // Şirket Tablosu İle Bağla 
        public Guid? CompanyId { get; set; }  // Firma / Şirket Id
        public virtual Company Company { get; set; }

        public Guid? DepartmentId { get; set; }

        public virtual Department Department { get; set; }


        public bool IsActive { get; set; } // Aktif mi ? 
        public bool IsBlocked { get; set; } // Bloked Durumu

        public string MediesIds { get; set; } // Media (ekler)
        public Media Media { get; set; }
        public List<NotificationSend> NotificationSends { get; set; }
        public List<Visit> Visits { get; set; }

        public bool IsKvkk { get; set; } // Kvkk Metni oynaylandı mı ?

        public bool IsApprovedIllumintionText { get; set; } // Aydınlatma Metni Onaylandı mı ?
         
        // public ICollection<VisitDetailUser> VisitDetailUsers { get; set; }







    }
}
