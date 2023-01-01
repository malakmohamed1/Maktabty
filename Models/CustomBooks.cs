using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_.Models
{
    [MetadataType(typeof(CustomUsers))]
    public partial class Books
    {
    }

    public class CustomBooks
    {
        [Required]
        [Display(Name = "Book ID")]
        public int BookID { get; set; }
        [Required]
        [Display(Name = "Book name")]
        public string Book_Name { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "Cover type")]
        public string Cover_Type { get; set; }
        [Required]
        [Display(Name = "Book type")]
        public string Book_Type { get; set; }

        [Required]
        [Display(Name = "Admin ID")]
        public int AdminID { get; set; }
        [Required]
        [Display(Name = "Book description")]
        public string Book_Description { get; set; }
    }
}