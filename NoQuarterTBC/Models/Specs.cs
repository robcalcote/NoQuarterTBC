using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoQuarterTBC.Models
{
    // Specs Table
    [Table("Specs")]
    public class Specs
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Spec ID")]
        public int SpecID { get; set; }
        #region Links
        // Link back to the Players Table
        public virtual ICollection<Players> players { get; set; }
        #endregion

        [Required(ErrorMessage = "A Spec Name is required.")]
        [StringLength(30, ErrorMessage = "Spec Name must not exceed 30 characters.")]
        [DisplayName("Spec Name")]
        public string SpecName { get; set; }

        // Link to the GameRoles Table
        [Required(ErrorMessage = "Game Role ID is required.")]
        [DisplayName("Game Role ID")]
        [ForeignKey("gameroles")]
        public int GameRoleID { get; set; }
        public virtual GameRoles gameroles { get; set; }

        // Link to the Classes Table
        [Required(ErrorMessage = "Class ID is required.")]
        [DisplayName("Class ID")]
        [ForeignKey("classes")]
        public int ClassID { get; set; }
        public virtual Classes classes { get; set; }
    }
}