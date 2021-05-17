using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FCC_ASPNC_WebApp.Models
{
    /// <summary>
    /// Application Type Model for Assignment - to be pushed to database
    /// </summary>
    public class ApplicationType
    {
        //Uses Notation to specify a primary key
        [Key]
        public int ApplicationId { get; set; }
        //Using Notation to display property with a different name in Create View
        [DisplayName("Application Type")]
        public string ApplicationName { get; set; }


    }
}
