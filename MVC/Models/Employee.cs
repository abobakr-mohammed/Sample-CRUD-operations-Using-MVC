using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace D4.Models
{
    public class Employee
    {
        [Key]
        [Display(Name ="Ssn")]
        public int ID { get; set; }
        [Display(Name ="First Name")]
        [Required(ErrorMessage ="First Name is Required ..!")]
        public string FName { get; set; }
        [Display(Name ="Last Name")]
        [MinLength(5,ErrorMessage ="minimum length of last name is 5 characters")]
        [MaxLength(20,ErrorMessage ="maximun length of last name is 20 characters")]
        public string LName { get; set; }
        [Display(Name ="Age")]
        [Range(18,60,ErrorMessage ="Age must be between 18 - 60 years old")]
        public int Age { get; set; }
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="password field is required..!")]
        //[RegularExpression("")]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="password and confirm password don't match..!")]
        public string CPassword { get; set; }
        [DataType(DataType.Url)]
        [Url]
        public string Url { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Email Address is required..!")]
        [EmailAddress]
        [System.Web.Mvc.Remote("EmailExist", "Home",ErrorMessage ="Mail exists !!!")]
        public string Email { get; set; }

        [Display(Name ="Address")]
        [DataType(DataType.MultilineText)]
        public string Adddress { get; set; }

        [Display(Name ="Date Of Birth")]
        [DataType(DataType.Date)]
        [Column(TypeName ="date")]
        public DateTime DOB { get; set; }
        [Range(5000,15000,ErrorMessage ="Salary must be between 5000 and 15000 ")]
        [Column(TypeName ="money")]
        public decimal Salary { get; set; }
        [Display(Name = "Department")]
        [ForeignKey("Department")]
        public int DeptID { get; set; }
        public virtual Department Department { get; set; }


    }
}