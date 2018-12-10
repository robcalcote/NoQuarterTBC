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
    public class Players
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Player ID")]
        public int PlayerID { get; set; }
        /*  The Links below are all of the tables that are linked to the primary key of the player table (PlayerID) */
        #region Links
        // Link back to the Notes Table
        public virtual ICollection<Notes> notes { get; set; }
        // Link back to the PlayerProfessions Table
        public virtual ICollection<PlayerProfessions> playerprofessions { get; set; }
        // Link back to the PlayerAttunements Table
        public virtual ICollection<PlayerAttunements> playerattunements { get; set; }
        // Link back to the BankContributions Table
        public virtual ICollection<BankContributions> bankcontributions { get; set; }
        // Link back to the Promotions Table
        public virtual ICollection<Promotions> promotions { get; set; }
        // Link back to the RaidAttendance Table
        public virtual ICollection<RaidAttendance> raidattendance { get; set; }
        // Link back to the EncounterLoots Table
        public virtual ICollection<EncounterLoots> encounterloots { get; set; }
        #endregion

        [Required(ErrorMessage = "A Player Name is required.")]
        [StringLength(12, ErrorMessage = "Player Name must not exceed 12 characters.")]
        [DisplayName("Player Name")]
        public string PlayerName { get; set; }

        // Link to the Roles Table
        [Required(ErrorMessage = "Role ID is required.")]
        [DisplayName("Role ID")]
        [ForeignKey("roles")]
        public int RoleID { get; set; }
        public virtual Roles roles { get; set; }

        // Link to the Classes Table
        [Required(ErrorMessage = "Class ID is required.")]
        [DisplayName("Class ID")]
        [ForeignKey("classes")]
        public int AssayTypeID { get; set; }
        public virtual Classes classes { get; set; }

        // Link to the Specs Table
        [Required(ErrorMessage = "Spec ID is required.")]
        [DisplayName("Spec ID")]
        [ForeignKey("specs")]
        public int SpecID { get; set; }
        public virtual Specs specs { get; set; }

        [Required(ErrorMessage = "Login Password is required.")]
        [DisplayName("Login Password")]
        public string LoginPW { get; set; }
    }
}