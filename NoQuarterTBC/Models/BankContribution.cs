using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoQuarterTBC.Models
{
    // BankContributions Table
    [Table("BankContributions")]
    public class BankContribution
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Bank Contribution ID")]
        public int ContributionID { get; set; }

        // Link to the Players Table
        [Required(ErrorMessage = "A Player ID is required.")]
        [DisplayName("Player ID")]
        [ForeignKey("players")]
        public int? PlayerID { get; set; }
        public virtual Player players { get; set; }

        [Required(ErrorMessage = "An Item Name is required.")]
        [StringLength(30, ErrorMessage = "Item Name must not exceed 30 characters.")]
        [DisplayName("Item Name")]
        public string ContributionItem { get; set; }

        [Required(ErrorMessage = "A Quantity is required.")]
        [DisplayName("Quantity")]
        public int ContributionQuantity { get; set; }

        [Required(ErrorMessage = "A Contribution Date is required.")]
        [DisplayName("Contribution Date")]
        public DateTime ContributionDate { get; set; }
    }
}