using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsRealEstate2.Models
{
    public class Property
    {
        public int Id { get; set; }
        public int PropertModeID { get; set; }
        public decimal Size { get; set; }
        public int OwnerID { get; set; }
        public decimal Prize { get; set; }
        public int Bedroom { get; set; }
        public int Bathroom { get; set; }
        public DateTime Property_Completed_On { get; set; }
        public bool lift { get; set; }
        public int Balcony { get; set; }
        public bool Backyard { get; set; }
        public bool SwimingPool { get; set; }
        public int Parking { get; set; }
        public string Comment { get; set; }
        public decimal Rating { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public int LocationId { get; set; }
        public string Address { get; set; }
        public int PinCode { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}