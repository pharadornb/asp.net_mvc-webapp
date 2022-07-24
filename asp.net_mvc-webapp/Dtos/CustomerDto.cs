using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace asp.net_mvc_webapp.Dtos
{
    public class CustomerDto
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Email { get; set; }
        //public string Phone { get; set; }
        //public DateTime? BirthDate { get; set; }
        //public string MembershipType { get; set; }
        //public byte MembershipTypeId { get; set; }

        public int Id { get; set; }

        //[Required]
        //[StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        //public MembershipType MembershipType { get; set; }

        //[Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        //can change label name have effect to razor, default
        //[Display(Name = "Date of Birth")]
        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}