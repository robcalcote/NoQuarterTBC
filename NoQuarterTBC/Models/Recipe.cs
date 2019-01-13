using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoQuarterTBC.Models
{
    // Recipes Table
    [Table("Recipes")]
    public class Recipe
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Recipe ID")]
        public int RecipeID { get; set; }
        #region Links
        // Link back to the PlayerRecipes Table
        public virtual ICollection<PlayerRecipe> playerrecipes { get; set; }
        #endregion

        [Required(ErrorMessage = "A Recipe Name is required.")]
        [StringLength(30, ErrorMessage = "Recipe Name must not exceed 30 characters.")]
        [DisplayName("Recipe Name")]
        public string RecipeName { get; set; }

        // Link to the Professions Table
        [Required(ErrorMessage = "Profession ID is required.")]
        [DisplayName("Profession ID")]
        //[ForeignKey("professions")]
        public int ProfessionID { get; set; }
        public virtual Profession professions { get; set; }
    }
}