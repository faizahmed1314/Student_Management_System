using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    [MetadataType(typeof(BatchMetaData))]
    public partial class Batch
    {
    }

    public class BatchMetaData
    {
        [Display(Name = "Batch")]
        [Required(ErrorMessage = "Batch field is required!")]
        public string batch1 { get; set; }


        [Display(Name = "Year")]
        public Nullable<int> year { get; set; }
    }
}