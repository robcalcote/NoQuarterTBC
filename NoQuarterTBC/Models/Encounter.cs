using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoQuarterTBC.Models
{
    // Encounters Table
    [Table("Encounters")]
    public class Encounter
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Encounter ID")]
        public int EncounterFight { get; set; }
        #region Links
        // Link back to the RaidAttendance Table
        public virtual ICollection<EncounterLoot> encounterloots { get; set; }
        #endregion

        // Link to the Bosses Table
        [Required(ErrorMessage = "A Boss ID is required.")]
        [DisplayName("Boss ID")]
        [ForeignKey("bosses")]
        public int BossID { get; set; }
        public virtual Boss bosses { get; set; }

        [Required(ErrorMessage = "Boss First Kill is required.")]
        // if 1 - First Kill. if 0 - Not First Kill (Farm)
        [DisplayName("Boss First Kill?")]
        public bool BossFirstKill { get; set; }

        [DisplayName("Boss Kill Time")]
        public TimeSpan? BossKillTime { get; set; }
    }
}