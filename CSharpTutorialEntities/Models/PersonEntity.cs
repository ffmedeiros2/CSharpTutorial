using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSharpTutorialEntities.Models
{
    public class PersonEntity
    {
        [Key]
        public Guid PersonEntityID { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
