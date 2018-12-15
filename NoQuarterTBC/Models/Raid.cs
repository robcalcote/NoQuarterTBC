using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoQuarterTBC.Models
{
    // Raids Table
    [Table("Raids")]
    public class Raid
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Raid ID")]
        public int RaidID { get; set; }
        #region Links
        // Link back to the RaidAttendance Table
        public virtual ICollection<RaidInstance> raidinstances { get; set; }
        // Link back to the Bosses Table
        public virtual ICollection<Boss> bosses { get; set; }
        #endregion

        [Required(ErrorMessage = "A Raid Name is required.")]
        [StringLength(30, ErrorMessage = "Raid Name must not exceed 30 characters.")]
        [DisplayName("Raid Name")]
        public string RaidName { get; set; }

        [Required(ErrorMessage = "A Raid Release Date is required.")]
        [DisplayName("Raid Release Date")]
        public DateTime RaidReleaseDate { get; set; }
    }
}