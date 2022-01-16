using IntimeVisitor.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Entities.Domain
{
   public class UserSetting:BaseEntity,IEntity
    {
       
    
        //[MaxLength(30)]
        //[Required(ErrorMessage = "Lütfen Kullanıcı Ayar Adını Yazınız.")]
        public string UserSettingName { get; set; }
        //[MaxLength(150)]

        //[Required(ErrorMessage = "Lütfen Kullanıcı Ayar Açıklamasını Yazınız.")]
        public string Description { get; set; }
    }
}
