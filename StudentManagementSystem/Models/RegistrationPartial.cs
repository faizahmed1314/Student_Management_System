using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    [MetadataType(typeof(RegistrationMetaData))]
    public partial class Registration
    {
    }

    public class RegistrationMetaData
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required!")]
        public string firstname { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required!")]
        public string lastname { get; set; }

        [Display(Name = "National Id")]
        [Required(ErrorMessage = "National id card is required!")]
        public Nullable<int> nic { get; set; }
        public Nullable<int> batch_id { get; set; }
        public Nullable<int> course_id { get; set; }

        [DisplayName("Phone No")]
        [Required(ErrorMessage = "Phone No is required!")]
        public Nullable<int> phone { get; set; }
    }
}