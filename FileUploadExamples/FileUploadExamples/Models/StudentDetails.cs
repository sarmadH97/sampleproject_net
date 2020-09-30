using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploadExamples.Models
{
    public class StudentDetails
    {
        [Key]
        public int id { get; set; }

        [Required][Display(Name ="Student Name")]
        public string Sname { get; set; }
        [Required]
        [MinLength(4,ErrorMessage ="Batch cannot be less than 4 characters")]
        [MaxLength(5,ErrorMessage ="Batch cannot be greater than 5 characters")]
        public string batch { get; set; }
        [Required][Display(Name ="Choose Image")]
        public string ImagePath { get; set; }
    }
}
