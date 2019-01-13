using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoQuarterTBC.Models
{
    // Promotions Table
    [Table("Promotions")]
    public class Promotion
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Promotion ID")]
        public int PromotionID { get; set; }

        // Link to the Players Table
        [Required(ErrorMessage = "A Player ID is required.")]
        [DisplayName("Player ID")]
        //[ForeignKey("players")]
        public int PlayerID { get; set; }
        public virtual Player players { get; set; }

        // Link to the GuildRanks Table - For New Rank
        [Required(ErrorMessage = "A Rank ID is required.")]
        [DisplayName("Rank ID")]
        //[ForeignKey("guildranks")]
        public int RankID { get; set; }
        public virtual GuildRank guildranks { get; set; }

        [Required(ErrorMessage = "A Promotion Date is required.")]
        [DisplayName("Promotion Date")]
        public DateTime PromotionDate { get; set; }
    }
}