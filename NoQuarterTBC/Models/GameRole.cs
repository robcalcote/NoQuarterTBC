using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoQuarterTBC.Models
{
    // GameRoles Table
    [Table("GameRoles")]
    public class GameRole
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Game Role ID")]
        public int GameRoleID { get; set; }
        #region Links
        // Link back to the Specs Table
        public virtual ICollection<Spec> specs { get; set; }
        #endregion

        [Required(ErrorMessage = "A Game Role Name is required.")]
        [StringLength(16, ErrorMessage = "Game Role Name must not exceed 16 characters.")]
        [DisplayName("Game Role Name")]
        public string GameRoleName { get; set; }
    }
}