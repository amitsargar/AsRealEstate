using System;
using System.ComponentModel.DataAnnotations;

namespace AsRealEstate2.Models
{
    public class PropertyMode
    {
        [Key]
        public int PropertyModeId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}