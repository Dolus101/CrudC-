using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DizonCoop.Models
{
    public class ClientInfoViewModel
    {
        public int Id { get; set; }

        [DisplayName("Pick User Type")]
        [Required]
        public int? Usertype { get; set; }

        [DisplayName("Enter Frist Name")]
        [Required]
        public string? FirstName { get; set; }

        [DisplayName("Enter Middle Name")]

        public string? MiddleName { get; set; }

        [DisplayName("Enter Last Name")]
        [Required]
        public string? LastName { get; set; }

        [DisplayName("Enter Address")]
        [Required]
        public string? Address { get; set; }

        [DisplayName("Enter Zip Code")]
        [Required]
        public int? ZipCode { get; set; }

        [DisplayName("Enter Birthdate")]
        //[Required]
        public DateTime? BirthDate { get; set; }

        [DisplayName("Enter Age")]
        [Required]
        public int? Age { get; set; }

        [DisplayName("Enter Name Of Father")]
        [Required]
        public string? NameOfFather { get; set; }

        [DisplayName("Enter Name Of Mother")]
        [Required]
        public string? NameOfMother { get; set; }

        [DisplayName("Enter Civil Status")]
        [Required]
        public string? CivilStatus { get; set; }

        [DisplayName("Enter Relgion")]
        [Required]
        public string? Relgion { get; set; }

        [DisplayName("Enter Occupation")]
        [Required]
        public string? Occupation { get; set; }
    }
}

