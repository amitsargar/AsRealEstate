using System.ComponentModel.DataAnnotations;

namespace AsRealEstate2.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
    }
}