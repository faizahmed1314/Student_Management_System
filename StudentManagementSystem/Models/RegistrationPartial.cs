using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManagementSystem.Common;

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

        //When range attribute is used with dateTime field, the client side validation isn't work as expected.
        //[Range(typeof(DateTime), "01/01/2000", "01/01/2020")]
        //custom date attribute added with minimum value
        //[DataRange("10/10/2000")]
        //Custom date attribute added from no restriction with current date
        [CurrentDate]
       
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> Date { get; set; }

        [Range(1,100000)]
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