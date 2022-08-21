using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsRealEstate2.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public Nullable<int> CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual Member Member { get; set; }
    }
}