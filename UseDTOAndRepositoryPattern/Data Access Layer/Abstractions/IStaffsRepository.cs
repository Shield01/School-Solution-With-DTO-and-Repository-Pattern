using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseDTOAndRepositoryPattern.Models;

namespace UseDTOAndRepositoryPattern.Data_Access_Layer.Abstractions
{
    public interface IStaffsRepository
    {
        IEnumerable<Staff> GetAll();

        Staff Get(int id);

        void Create(Staff newStaff);

        Staff CreateAndReturn(Staff newStaff);

        void Update(Staff updatedStaff);

        void Delete(int id);
    }
}
