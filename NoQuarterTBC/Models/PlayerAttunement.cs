using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoQuarterTBC.Models
{
    // PlayerAttunements Table
    // Linking Table for Players and Attunements
    [Table("PlayerAttunements")]
    public class PlayerAttunement
    {
        // Link to the Attunements Table
        [Key, Required, Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Attunement ID")]
        //[ForeignKey("attunements")]
        public int AttuneID { get; set; }
        public virtual Attunement attunements { get; set; }

        // Link to the Players Table
        [Key, Required, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Player ID")]
        //[ForeignKey("players")]
        public int PlayerID { get; set; }
        public virtual Player players { get; set; }

        [Required(ErrorMessage = "An Achieved Date is required.")]
        [DisplayName("Date Achieved")]
        public DateTime DateAchieved { get; set; }
    }
}