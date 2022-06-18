using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace asp.net_mvc_webapp.Models
{
    public class Customer
    {
        /*
            - add-migration AddIsSubscribedToCustomer
            - Update-Database
            - Overide convention *PK, *FK, data type
         */
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}