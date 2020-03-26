using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Models
{
    [MetadataType(typeof(RegistrationMetaData))]
    public partial class Registration
    {
    }

    public class RegistrationMetaData
    {
        [HiddenInput(DisplayValue = false)]
        public int id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required!")]
        public string firstname { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required!")]
        public string lastname { get; set; }

        [DisplayFormat(NullDisplayText = "Gender is not specified!")]
        [DisplayName("Gender")]
        public string gender { get; set; }

        [Display(Name = "National Id")]
        [Required(ErrorMessage = "National id card is required!")]
        public Nullable<int> nic { get; set; }

        [DisplayName("Batch")]
        public Nullable<int> batch_id { get; set; }

        [DisplayName("Course")]
        public Nullable<int> course_id { get; set; }

        [DisplayName("Phone No")]
        [Required(ErrorMessage = "Phone No is required!")]
        public Nullable<int> phone { get; set; }

       //[DisplayFormat(DataFormatString = "{0:d}")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> Date { get; set; }

        [DisplayName("Salary")]
        [ScaffoldColumn(true)]
        [DataType(DataType.Currency)]
        public int? salary { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [DisplayName("Personal Website")]
        [DataType(DataType.Url)]
        [UIHint("OpenInNewWindow")]
        public string personalWebsite { get; set; }
    }
}