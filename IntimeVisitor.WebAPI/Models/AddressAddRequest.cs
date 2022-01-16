using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntimeVisitor.WebAPI.Models
{
    public class AddressAddRequest: BaseRequest
    {
        public string OpenAdress { get; set; }
    }
}