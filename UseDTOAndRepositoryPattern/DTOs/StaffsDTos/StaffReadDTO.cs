using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UseDTOAndRepositoryPattern.DTOs.StaffsDTos
{
    public class StaffReadDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }
    }
}
