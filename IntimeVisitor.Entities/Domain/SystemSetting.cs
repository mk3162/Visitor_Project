using IntimeVisitor.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Entities.Domain
{
 public   class SystemSetting:BaseEntity,IEntity
    {


        //[Required(ErrorMessage = "Lütfen Sistem Ayar Adını Yazınız.")]
      //  [MaxLength(30)]
        public string SytemSettingName { get; set; }

       // [Required(ErrorMessage = "Lütfen Açıklama Yazınız.")]
       // [MaxLength(150)]
        public string Description { get; set; }
    }
}
