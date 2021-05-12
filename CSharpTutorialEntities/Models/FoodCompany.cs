using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSharpTutorialEntities.Models
{
    public class FoodCompany
    {
        [Key]
        public Guid FoodCompanyID { get; set; }

        [Required]
        public string FoodComanyName { get; set; }
    }
}
