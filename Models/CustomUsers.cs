using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Project_.Models
{
    [MetadataType(typeof(CustomUsers))]
    public partial class User
    {
    }
    public class CustomUsers
    {
        [Required]
        [Display(Name="National ID")]
        public string NatID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}