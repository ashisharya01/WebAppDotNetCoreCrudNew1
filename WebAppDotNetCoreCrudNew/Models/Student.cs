using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDotNetCoreCrudNew.Models
{
    public class Student
    {
        [Key]
        public int CustomerID { get; set; }



        [Required(ErrorMessage = "Required")]
        public string Fname { get; set; }


        [Required(ErrorMessage = "Required")]
        public string Lname { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Mobile { get; set; }

        public string Country_code { get; set; }

        [Required(ErrorMessage = "Required")]
        [NotMapped]
        public string Gender { get; set; }

        public decimal Balance { get; set; }
    }
}
