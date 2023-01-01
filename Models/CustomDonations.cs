using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Xml.Linq;

namespace Project_.Models
{
    [MetadataType(typeof(CustomDonation))]

    public partial class Donation
    {

    }
    public class CustomDonation
    {

        public int TransactionID { get; set; }

        [Required]
        [Display(Name = "Donation amount")]
        public int Amount { get; set; }

        [Required]
        [Display(Name = "Date of Donation")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: YYYY-MM-DD hh:mm}")]
        public System.DateTime Date { get; set; }

        [Required]
        [Display(Name = "National ID")]
        public string NatID { get; set; }

    }

}
