using IntimeVisitor.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Entities.Domain
{
   public class WorkflowSteps:BaseEntity,IEntity
    {
       
        //[Required(ErrorMessage = "Lütfen İş Akış Adım Kodunu Yazınız.")]
        //[MaxLength(30)]
        public string WorkflowStepCode { get; set; }
        //[Required(ErrorMessage = "Lütfen  Adım No Yazınız.")]
        //[MaxLength(30)]
        public string StepNumber { get; set; }
        //[Required(ErrorMessage = "Lütfen İş Akış Adım Detay Yazınız.")]
        //[MaxLength(30)]
        public string StepDetails { get; set; }
        //[Required(ErrorMessage = "Lütfen Mesajı Seçiniz.")]
        public Guid? MessageId { get; set; }

        public List<Workflow> Workflows { get; set; }
    }
}
