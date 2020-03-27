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
        [Display(Name = "First Name")]
        public string firstname { get; set; }

        [Display(Name = "Last Name")]
        public string lastname { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User name is required!")]
        public string username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required!")]
        public string password { get; set; }
    }
}