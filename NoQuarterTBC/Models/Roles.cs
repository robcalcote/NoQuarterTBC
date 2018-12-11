﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoQuarterTBC.Models
{
    // Roles Table
    [Table("Roles")]
    public class Roles
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Role ID")]
        public int RoleID { get; set; }
        #region Links
        // Link back to the Notes Table
        public virtual ICollection<Notes> notes { get; set; }
        // Link back to the Rights Table
        public virtual Rights rights { get; set; }
        #endregion

        [Required(ErrorMessage = "A Role Name is required.")]
        [StringLength(30, ErrorMessage = "Role Name must not exceed 30 characters.")]
        [DisplayName("Role Name")]
        public string RoleName { get; set; }
    }
}