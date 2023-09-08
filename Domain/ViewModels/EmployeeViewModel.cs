using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class EmployeeViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string? LastName { get; set; }


        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }


        [RegularExpression("^[MF]$", ErrorMessage = "Gender should be 'M' or 'F'")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Gender must be exactly 1 character")]
        public string? Gender { get; set; }


        [Range(0, 1, ErrorMessage = "MaritalStatus must be 0 or 1")]
        public byte MaritalStatus { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "Birth Date is required")]
        //[Range(typeof(DateTime), "1900-01-01", "2015-12-31", ErrorMessage = "You must be at least 18 years old.")]
        public DateTime BirthDate { get; set; }


        [RegularExpression(@"^(reading|surfing|singing)$", ErrorMessage = "Invalid hobby. Allowed hobbies are: reading, surging, singing")]
        [StringLength(100)]
        public string? Hobbies { get; set; }

        [Range(5000.01, double.MaxValue, ErrorMessage = "Salary must be greater than 5000")]
        public decimal Salary { get; set; }

        [StringLength(500)]
        public string? Address { get; set; }

        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }

        [RegularExpression(@"^\d{6}$", ErrorMessage = "ZipCode must be exactly 6 digits")]
        public string? ZipCode { get; set; }


        [RegularExpression(@"^(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*()_+{}\[\]:;<>,.?~\\]).{6,16}$", ErrorMessage = "Password must have at least 1 uppercase, 1 number, and 1 special character, and be 6 to 16 characters long")]
        public string? Password { get; set; }
        public DateTime CreatedDate { get; set; }
        [NotMapped]
        public IFormFile? Files { get; set; }

        public string? ImageName { get; set; }

    }
}
