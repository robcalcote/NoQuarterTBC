using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoQuarterTBC.Models
{
    // Professions Table
    [Table("Professions")]
    public class Profession
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Profession ID")]
        public int ProfessionID { get; set; }
        #region Links
        // Link back to the PlayerProfessions Table
        public virtual ICollection<PlayerProfession> playerprofessions { get; set; }
        #endregion

        [Required(ErrorMessage = "A Profession Name is required.")]
        [StringLength(30, ErrorMessage = "Profession Name must not exceed 30 characters.")]
        [DisplayName("Profession Name")]
        public string ProfessionName { get; set; }

        [Required(ErrorMessage = "You must select whether this profession is Primary or Secondary.")]
        // if 1 - Primary. if 0 - Secondary
        [DisplayName("Primary / Secondary")]
        public bool Primary { get; set; }
    }
}