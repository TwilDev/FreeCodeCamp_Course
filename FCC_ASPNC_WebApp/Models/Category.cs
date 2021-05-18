using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FCC_ASPNC_WebApp.Models
{
    /// <summary>
    /// Category Model to be pushed into the DB
    /// </summary>
    public class Category
    {
        //Uses Notation to specify a primary key
        [Key]
        public int CategoryId { get; set; }
        //Notation used to make sure a field is required for validation
        [Required]
        public string Name { get; set; }
        //Using Notation to display property with a different name in Create View
        [DisplayName("Display Order")]
        //Notation used for require as as well data validation showing the range for the dropdown box and an error message
        [Required]
        [Range(1, int.MaxValue,ErrorMessage ="Display Order for category must be greater than 0")]
        public int DisplayOrder { get; set; }
    }
}
