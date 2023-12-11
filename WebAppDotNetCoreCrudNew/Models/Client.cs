using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebAppDotNetCoreCrudNew.Models;

namespace WebAppDotNetCoreCrudNew.Models
{
    public class Client
    {
        [Key]
        [Required(ErrorMessage = "Required")]
        public int ID { get; set; }



        [Required(ErrorMessage = "Required")]
        public string Firstname { get; set; }


        [Required(ErrorMessage = "Required")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Phone_Number { get; set; }

        public string Country_code { get; set; }

        [Required(ErrorMessage = "Required")]
        [NotMapped]
        public char Gender { get; set; }

        public decimal Balance { get; set; }
    }

}