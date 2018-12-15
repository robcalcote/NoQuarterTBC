using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoQuarterTBC.Models
{
    // Classes Table
    [Table("Classes")]
    public class Class
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Class ID")]
        public int ClassID { get; set; }
        #region Links
        // Link back to the Players Table
        public virtual ICollection<Player> players { get; set; }
        // Link back to the Specs Table
        public virtual ICollection<Spec> specs { get; set; }
        #endregion
        
        [Required(ErrorMessage = "A Class Name is required.")]
        [StringLength(12, ErrorMessage = "Class Name must not exceed 12 characters.")]
        [DisplayName("Class Name")]
        public string ClassName { get; set; }
    }
}