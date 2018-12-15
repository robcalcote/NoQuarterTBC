using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoQuarterTBC.Models
{
    // Players Table
    [Table("Players")]
    public class Player
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Player ID")]
        public int PlayerID { get; set; }
        #region Links
        // Link back to the Notes Table
        public virtual ICollection<Note> notes { get; set; }
        // Link back to the PlayerProfessions Table
        public virtual ICollection<PlayerProfession> playerprofessions { get; set; }
        // Link back to the PlayerAttunements Table
        public virtual ICollection<PlayerAttunement> playerattunements { get; set; }
        // Link back to the BankContributions Table
        public virtual ICollection<BankContribution> bankcontributions { get; set; }
        // Link back to the Promotions Table
        public virtual ICollection<Promotion> promotions { get; set; }
        // Link back to the RaidAttendance Table
        public virtual ICollection<RaidAttendance> raidattendance { get; set; }
        // Link back to the EncounterLoots Table
        public virtual ICollection<EncounterLoot> encounterloots { get; set; }
        #endregion

        [Required(ErrorMessage = "A Player Name is required.")]
        [StringLength(12, ErrorMessage = "Player Name must not exceed 12 characters.")]
        [DisplayName("Player Name")]
        public string PlayerName { get; set; }

        // Link to the Roles Table
        [Required(ErrorMessage = "Role ID is required.")]
        [DisplayName("Role ID")]
        [ForeignKey("roles")]
        public int? RoleID { get; set; }
        public virtual Role roles { get; set; }

        // Link to the Classes Table
        [Required(ErrorMessage = "Class ID is required.")]
        [DisplayName("Class ID")]
        [ForeignKey("classes")]
        public int? AssayTypeID { get; set; }
        public virtual Class classes { get; set; }

        // Link to the Specs Table
        [Required(ErrorMessage = "Spec ID is required.")]
        [DisplayName("Spec ID")]
        [ForeignKey("specs")]
        public int? SpecID { get; set; }
        public virtual Spec specs { get; set; }

        [Required(ErrorMessage = "Login Password is required.")]
        [DisplayName("Login Password")]
        public string LoginPW { get; set; }
    }
}