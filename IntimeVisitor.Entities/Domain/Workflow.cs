using IntimeVisitor.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Entities.Domain
{
    public class Workflow:BaseEntity,IEntity
    {
       

    
        public Guid? WorkflowStepId { get; set; }
        public virtual WorkflowSteps WorkflowSteps { get; set; }
        public string WorkflowName { get; set; }
        public List<NotificationSend> NotificationSends { get; set; }
    }
}
