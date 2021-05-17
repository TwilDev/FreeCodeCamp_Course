using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
