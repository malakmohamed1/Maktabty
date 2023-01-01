using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Project_.Models
{
    [MetadataType(typeof(CustomAdmin))]

    public partial class Admin
    {

    } 
    public class CustomAdmin
    {
        
        public int AdminID { get; set; }
        [Required]
        [Display(Name = "Admin name")]
        public string Admin_Name { get; set; }
        [Required]
        [Display(Name = "National ID")]
        public string NationalID { get; set; }
        [Required]
        
        public string Password { get; set; }

    }

}