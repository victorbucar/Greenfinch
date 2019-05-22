using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Greenfinch.WebDeveloper.Data.Models
{
    public class Newsletter
    {
        public int Id { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email format.")]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Heard about us")]
        [Required]
        public HeardAbout HeardAbout { get; set; }
        [Display(Name = "Reason for signing up (optional)")]
        public string SignUpReason { get; set; }
    }

    public enum HeardAbout
    {
        [Display(Name = "Advert")]
        Advert = 1,
        [Display(Name = "Word of mouth")]
        WordOfMouth = 2,
        [Display(Name = "Other")]
        Other = 3
    }
}
