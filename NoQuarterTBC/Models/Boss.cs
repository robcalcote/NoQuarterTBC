using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoQuarterTBC.Models
{
    // Bosses Table
    [Table("Bosses")]
    public class Boss
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Boss ID")]
        public int BossID { get; set; }
        #region Links
        // Link back to the Encounters Table
        public virtual ICollection<Encounter> encounters { get; set; }
        // Link back to the Loots Table
        public virtual ICollection<Loot> loots { get; set; }
        #endregion

        [Required(ErrorMessage = "A Boss Name is required.")]
        [StringLength(30, ErrorMessage = "Boss Name must not exceed 30 characters.")]
        [DisplayName("Boss Name")]
        public string BossName { get; set; }

        // Link to the Raids Table
        [Required(ErrorMessage = "A Raid ID is required.")]
        [DisplayName("Raid ID")]
        [ForeignKey("raids")]
        public int? RaidID { get; set; }
        public virtual Raid raids { get; set; }
    }
}