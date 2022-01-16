using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntimeVisitor.Entities.Domain
{
  public  class BaseEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            Code = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
            CreatedDate = DateTime.Now;
            IsDeleted = false;
            //DeletedDate = DateTime.Now;
           
        }

        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        [Column(TypeName = "Bit")]
        public bool? IsDeleted { get; set; }
     

  

    }
}
