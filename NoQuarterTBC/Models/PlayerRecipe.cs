using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoQuarterTBC.Models
{
    // PlayerRecipe Table
    // Linking Table for Players and Recipes
    [Table("PlayerRecipes")]
    public class PlayerRecipe
    {
        // Link to the Players Table
        [Key, Required, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Player ID")]
        //[ForeignKey("players")]
        public int PlayerID { get; set; }
        public virtual Player players { get; set; }

        // Link to the Recipes Table
        [Key, Required, Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Recipe ID")]
        //[ForeignKey("recipe")]
        public int RecipeID { get; set; }
        public virtual Recipe recipes { get; set; }
    }
}