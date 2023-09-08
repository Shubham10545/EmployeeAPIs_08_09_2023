using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.ViewModels
{
    public class GetAllEmployeeData
    {
        
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Gender { get; set; }

        public byte MaritalStatus { get; set; }

        public DateTime BirthDate { get; set; }
        public string? Hobbies { get; set; }

        public string? PhotoUrl { get; set; }

        public decimal Salary { get; set; }

        public string? Address { get; set; }

        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string?  ZipCode { get; set; }

        public string? Password { get; set; }
        

    }
}
