using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoQuarterTBC.Models
{
    // Loots Table
    [Table("Loots")]
    public class Loot
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Loot ID")]
        public int LootID { get; set; }
        #region Links
        // Link back to the EncounterLoots Table
        public virtual ICollection<EncounterLoot> encounterloots { get; set; }
        #endregion

        [Required(ErrorMessage = "A Loot Name is required.")]
        [StringLength(30, ErrorMessage = "Loot Name must not exceed 30 characters.")]
        [DisplayName("Loot Name")]
        public string LootName { get; set; }

        // Link to the Bosses Table
        [Required(ErrorMessage = "A Boss ID is required.")]
        [DisplayName("Boss ID")]
        [ForeignKey("bosses")]
        public int? BossID { get; set; }
        public virtual Boss bosses { get; set; }
    }
}