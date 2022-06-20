using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using asp.net_mvc_webapp.Models;

namespace asp.net_mvc_webapp.ViewModels
{
    public class CustomerFormViewModel
    {
        //IEnumerable mean is class can refer to interface can use foreach print data
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}