using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DizonCoop.Models
{
public class ClientInfoViewModel
    {
        public int Id { get; set; }
        // [Required]
        public int? Usertype { get; set; }
        public string UsertypeName { get; set; } = "";

        // [Required]
        public string? FirstName { get; set; }

        // [Required]
        public string? MiddleName { get; set; }

        // [Required]
        public string? LastName { get; set; }

        // [Required]
        public string? Address { get; set; }

        // [Required]
        public int? ZipCode { get; set; }

        // [Required]
        public DateTime? BirthDate { get; set; }

        // [Required]
        public int? Age { get; set; }

        // [Required]
        public string? NameOfFather { get; set; }

        // [Required]
        public string? NameOfMother { get; set; }

        // [Required]
        public string? CivilStatus { get; set; }

        // [Required]
        public string? Relgion { get; set; }

        // [Required]
        public string? Occupation { get; set; }
    }
}
