using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreWebApplication.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(15)]
        public string Name { get; set; }

        [RegularExpression(@"^([\w\.\-] +)@([\w\-] +)((\.(\w){2, 3})+)$", ErrorMessage = "Email is not valid")]        
        public string Email { get; set; }

        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Phone is not valid")]
        public string Phone { get; set; }
    }
}
