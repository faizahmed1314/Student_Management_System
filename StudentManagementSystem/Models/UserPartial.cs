using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
    }

    public class UserMetaData
    {
        [Required]
        [Display(Name = "First Name")]
        public string firstname { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lastname { get; set; }

        [StringLength(10, MinimumLength = 5, ErrorMessage = "The user name should be 5 to 10 character")]
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User name is required!")]
        public string username { get; set; }

        [StringLength(10, MinimumLength = 5,ErrorMessage = "The password should be 5 to 10 character")]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required!")]
        public string password { get; set; }
    }
}