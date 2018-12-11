using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoQuarterTBC.Models
{
    // PlayerProfessions Table
    // Linking Table for Players and Professions
    [Table("PlayerProfessions")]
    public class PlayerProfessions
    {
        // Link to the Professions Table
        [Key, Required, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Profession ID")]
        [ForeignKey("professions")]
        public int ProfessionID { get; set; }
        public virtual Professions professions { get; set; }

        // Link to the Players Table
        [Key, Required, Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Player ID")]
        [ForeignKey("players")]
        public int PlayerID { get; set; }
        public virtual Players players { get; set; }
    }
}