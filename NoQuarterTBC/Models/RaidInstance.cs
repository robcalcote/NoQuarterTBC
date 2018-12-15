using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoQuarterTBC.Models
{
    // RaidInstances Table
    [Table("RaidInstances")]
    public class RaidInstance
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Raid Instance ID")]
        public int RaidInstanceID { get; set; }
        #region Links
        // Link back to the RaidAttendance Table
        public virtual ICollection<RaidAttendance> raidattendance { get; set; }
        #endregion

        // Link to the Raids Table
        [Required(ErrorMessage = "A Raid ID is required.")]
        [DisplayName("Raid ID")]
        [ForeignKey("raids")]
        public int? RaidID { get; set; }
        public virtual Raid raids { get; set; }

        [Required(ErrorMessage = "A Raid Date is required.")]
        [DisplayName("Raid Date")]
        public DateTime RaidDate { get; set; }

        [Required(ErrorMessage = "Progression Raid is required.")]
        // if 1 - Progression. if 0 - Not Progression (Farm)
        [DisplayName("Progression Raid?")]
        public bool Progression { get; set; }

        [Required(ErrorMessage = "Raid Cleared is required.")]
        // if 1 - Cleared. if 0 - Not Cleared
        [DisplayName("Raid Cleared?")]
        public bool RaidCleared { get; set; }

        [Required(ErrorMessage = "A Raid Run Time is required.")]
        [DisplayName("Raid Run Time")]
        public TimeSpan RaidRunTime { get; set; }
    }
}