using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UseDTOAndRepositoryPattern.DTOs.StudentsDTOs
{
    public class StudentReadDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string StateOfOrigin { get; set; }
    }
}
