using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MarcomSurvey.Models
{
    public class GuestResponse
    {
        //      [HiddenInput(DisplayValue = false)]
        [Key]
        public int Sid { get; set; }

        [Required(ErrorMessage = "Please enter your Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your Email Address.")]
        [Display(Name = "Email Address")]
        //   [RegularExpression(".+\\@.+\\..+",
        //       ErrorMessage = "Please enter a valid email address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your Phone Number.")]
        [RegularExpression("\\d+",
            ErrorMessage = "Please enter only numbers.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please select whether you will attend.")]
        public bool? WillAttend { get; set; }
    }
}