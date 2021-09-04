using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UseDTOAndRepositoryPattern.Models
{
    public class Staff
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Qualification { get; set; }

        public int Salary { get; set; }

        public string Position { get; set; }
    }
}
