using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoQuarterTBC.Models
{
    // Rights Table
    [Table("Rights")]
    public class Privilege
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Rights ID")]
        public int RightsID { get; set; }

        // Link to the Roles Table
        [Required(ErrorMessage = "Role ID is required.")]
        [DisplayName("Role ID")]
        [ForeignKey("roles")]
        public int? RoleID { get; set; }
        public virtual Role roles { get; set; }

        [Required(ErrorMessage = "A Rights Name is required.")]
        [StringLength(30, ErrorMessage = "Rights Name must not exceed 30 characters.")]
        [DisplayName("Rights Name")]
        public string RightsName { get; set; }
    }
}