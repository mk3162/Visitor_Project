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
   public class LocalizationStrings:BaseEntity,IEntity
    {

        [StringLength(30)]
        public string WordKey { get; set; }


        [StringLength(30)]
        public string WordValue { get; set; }
    }
}
