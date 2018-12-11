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
    public class Promotions
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Promotion ID")]
        public int PromotionID { get; set; }

        // Link to the Players Table
        [Required(ErrorMessage = "A Player ID is required.")]
        [DisplayName("Player ID")]
        [ForeignKey("players")]
        public int PlayerID { get; set; }
        public virtual Players players { get; set; }

        // Link to the GuildRanks Table - For New Rank
        [Required(ErrorMessage = "A New Rank ID is required.")]
        [DisplayName("New Rank ID")]
        [ForeignKey("newguildranks")]
        public int NewRankID { get; set; }
        public virtual GuildRanks newguildranks { get; set; }

        [Required(ErrorMessage = "A Promotion Date is required.")]
        [DisplayName("Promotion Date")]
        public DateTime PromotionDate { get; set; }

        // Link to the GuildRanks Table - For Old Rank
        [Required(ErrorMessage = "An Old Rank ID is required.")]
        [DisplayName("Old Rank ID")]
        [ForeignKey("oldguildranks")]
        public int OldRankID { get; set; }
        public virtual GuildRanks oldguildranks { get; set; }
    }
}