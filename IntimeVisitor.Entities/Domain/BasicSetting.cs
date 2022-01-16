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
   public class BasicSetting:BaseEntity,IEntity
    {
        

       

        //[Required(ErrorMessage = "Lütfen Kullanıcı Başlangıç Ayar Adını Yazınız.")]
        [StringLength(30)]
        public string BasicSettingName { get; set; }

       // [Required(ErrorMessage = "Lütfen Kullanıcı Başlangıç Açıklaması Yazınız.")]
        [StringLength(150)]
        public string Description { get; set; }
    }
}
