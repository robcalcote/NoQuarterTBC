using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoQuarterTBC.Models
{
    // Attunements Table
    [Table("Attunements")]
    public class Attunements
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Attunement ID")]
        public int AttuneID { get; set; }
        #region Links
        // Link back to the PlayerProfessions Table
        public virtual ICollection<PlayerAttunements> playerattunements { get; set; }
        #endregion

        [Required(ErrorMessage = "A Attunement Name is required.")]
        [StringLength(30, ErrorMessage = "Attunement Name must not exceed 30 characters.")]
        [DisplayName("Attunement Name")]
        public string AttuneName { get; set; }
    }
}