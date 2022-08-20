using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AsRealEstate2.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public DateTime DOB { get; set; }
        public decimal ContactNo { get; set; }
        public string EmailId { get; set; }
        public int Gender { get; set; }
        //public string GenderName { get; set; }
        public string ImagePath { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}