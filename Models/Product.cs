using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDbFirstApprochExample.Models
{
    [Table("Products", Schema ="dbo")]
    public class Product
    {
        [Key]
        [Display(Name = "ProductID")]
        public long ProductID { get; set; }

        [Display(Name = "ProductName")]
        [Required]
        public string ProductName { get; set; }

        [Display(Name = "Price")]
        [Required]
        public Nullable<decimal> Price { get; set; }

        [Display(Name = "DateOfPurchase")]
        public Nullable<System.DateTime> DateOfPurchase { get; set; }

        [Display(Name = "AvailabilityStatus")]
        public string AvailabilityStatus { get; set; }
     
        [Required]
        public Nullable<long> CategoryID { get; set; }

        [Required]
        public Nullable<long> BrandID { get; set; }
        
        public Nullable<bool> Active { get; set; }


        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}