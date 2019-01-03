using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoQuarterTBC.Models
{
    // RaidAttendance Table
    [Table("RaidAttendance")]
    public class RaidAttendance
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Raid Attendance ID")]
        public int AttendanceID { get; set; }

        // Link to the Players Table
        [Required(ErrorMessage = "A Player ID is required.")]
        [DisplayName("Player ID")]
        //[ForeignKey("players")]
        public int PlayerID { get; set; }
        public virtual Player players { get; set; }

        // Link to the RaidInstances Table
        [Required(ErrorMessage = "A Raid Instance ID is required.")]
        [DisplayName("Raid Instance ID")]
        //[ForeignKey("raidinstances")]
        public int RaidInstanceID { get; set; }
        public virtual RaidInstance raidinstances { get; set; }

        [Required(ErrorMessage = "Total Attendance Count is required.")]
        [DisplayName("Total Attendance Count")]
        public float TotalAttendance { get; set; }

        [Required(ErrorMessage = "Recent Attendance is required.")]
        [DisplayName("Recent Attendance")]
        public float RecentAttendance { get; set; }
    }
}