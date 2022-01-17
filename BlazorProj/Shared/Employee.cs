using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProj.Shared
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required, Display(Name = "Jméno")]
        [MinLength(2, ErrorMessage = "Jméno musí obsahovat alespoň dva znaky")]        
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Příjmení")]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Datum narození")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Rod")]
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        public Department Department { get; set; }

    }
}
