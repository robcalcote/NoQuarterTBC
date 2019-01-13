using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoQuarterTBC.Models
{
    // GuildRanks Table
    [Table("GuildRanks")]
    public class GuildRank
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Guild Rank ID")]
        public int RankID { get; set; }
       // #region Links
        // Link back to the Promotions Table
      //  public virtual ICollection<Promotion> promotions { get; set; }
       // #endregion

        [Required(ErrorMessage = "A Guild Rank Name is required.")]
        [StringLength(30, ErrorMessage = "Guild Rank Name must not exceed 30 characters.")]
        [DisplayName("Guild Rank Name")]
        public string RankName { get; set; }
    }
}