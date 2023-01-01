using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_.Models
{
    [MetadataType(typeof(CustomBorrow))]
    public partial class CustomBorrow
    {
    }
    public class Borrows
    {
        [Required]
        [Display(Name = "National ID")]
        public string NatID { get; set; }
        [Required]
        [Display(Name = "Book ID")]
        public int BookID { get; set; }
        [Required]
        [Display(Name ="Taken Date")]
        public System.DateTime TakenDate { get; set; }
        [Required]
        [Display(Name = "Return Date")]
        public System.DateTime BroughtDate { get; set; }
        [Required]
        [Display(Name = "Book Quantity")]
        public int Book_Quantity { get; set; }
    }

}