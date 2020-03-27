using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    [MetadataType(typeof(CourseMetaData))]
    public partial class Course
    {
        
    }

    public class CourseMetaData
    {
        [Display(Name = "Course")]
        [Required(ErrorMessage = "Course field is required!")]
        public string course1 { get; set; }

        [DisplayName("Duration")]
        public Nullable<int> duration { get; set; }
    }
}