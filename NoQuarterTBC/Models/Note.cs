using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoQuarterTBC.Models
{
    // Notes Table
    [Table("Notes")]
    public class Note
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Note ID")]
        public int NotesID { get; set; }

        // Link to the Players Table
        [Required(ErrorMessage = "A Player ID is required.")]
        [DisplayName("Player ID")]
        [ForeignKey("players")]
        public int? PlayerID { get; set; }
        public virtual Player players { get; set; }

        [Required(ErrorMessage = "A Note is required.")]
        [DisplayName("Note")]
        public string NoteName { get; set; }

        [Required(ErrorMessage = "A Note Date is required.")]
        [DisplayName("Note Date")]
        public DateTime NoteDate { get; set; }

        [Required(ErrorMessage = "Private / Public Status is required.")]
        // if 0 - Private. if 1 - Public
        [DisplayName("Private / Public")]
        public bool PrivateNote { get; set; }
    }
}