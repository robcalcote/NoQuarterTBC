using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoQuarterTBC.Models
{
    // EncounterLoots Table
    // Linking Table for Players, Encounters, and Loots
    [Table("EncounterLoots")]
    public class EncounterLoots
    {
        // Link to the Encounters Table
        [Key, Required, Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Encounter ID")]
        [ForeignKey("encounters")]
        public int EncounterID { get; set; }
        public virtual Encounters encounters { get; set; }

        // Link to the Loots Table
        [Key, Required, Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Loot ID")]
        [ForeignKey("loots")]
        public int LootID { get; set; }
        public virtual Loots loots { get; set; }

        // Link to the Players Table
        [Key, Required, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Player ID")]
        [ForeignKey("players")]
        public int PlayerID { get; set; }
        public virtual Players players { get; set; }

        [Required(ErrorMessage = "Loot Disenchanted is required.")]
        // if 1 - Item Disenchanted. if 0 - Item Not Disenchanted
        [DisplayName("Loot Disenchanted?")]
        public bool Disenchanted { get; set; }
    }
}