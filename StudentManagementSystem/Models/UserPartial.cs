using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManagementSystem.Common;

namespace StudentManagementSystem.Models
{
    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
    }

    public class UserMetaData
    {
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Please enter upper case and lower case character only!")]
        [Required]
        [Display(Name = "First Name")]
        public string firstname { get; set; }
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Please enter upper case and lower case character only!")]
        [Required]
        [Display(Name = "Last Name")]
        public string lastname { get; set; }

        [StringLength(10, MinimumLength = 5, ErrorMessage = "The user name should be 5 to 10 character")]
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User name is required!")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Please enter upper case and lower case character only!")]
        //This validation use when javascript is active for the browser
        //[Remote("IsUserNameExist", "User", ErrorMessage = "User name already exist!")]
        //When javascript is disable for the browser we need remote client server custom validation
        [RemoteClientServer("IsUserNameExist", "User", ErrorMessage = "User name already exist!")]
        public string username { get; set; }

        [StringLength(10, MinimumLength = 5,ErrorMessage = "The password should be 5 to 10 character")]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required!")]
        public string password { get; set; }
    }
}