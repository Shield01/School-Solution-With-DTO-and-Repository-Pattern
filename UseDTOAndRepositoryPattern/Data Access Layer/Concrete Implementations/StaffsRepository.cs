using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseDTOAndRepositoryPattern.Data_Access_Layer.Abstractions;
using UseDTOAndRepositoryPattern.Models;

namespace UseDTOAndRepositoryPattern.Data_Access_Layer.Concrete_Implementations
{
    public class StaffsRepository : IStaffsRepository
    {
        public StaffsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly ApplicationDbContext _dbContext;

        public void Create(Staff newStaff)
        {
            _dbContext.Add(newStaff);
            _dbContext.SaveChanges();
        }

        public Staff CreateAndReturn(Staff newStaff)
        {
            _dbContext.Add(newStaff);
            _dbContext.SaveChanges();
            return newStaff;
        }

        public void Delete(int id)
        {
            var result = _dbContext.Staffs.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(result);
            _dbContext.SaveChanges();
        }

        public Staff Get(int id)
        {
            var result = _dbContext.Staffs.FirstOrDefault(x => x.Id == id);
            return (result);
        }

        public IEnumerable<Staff> GetAll()
        {
            var result = _dbContext.Staffs;
            return result;
        }

        public void Update(Staff updatedStaff)
        {
            //var result = _dbContext.Staffs.FirstOrDefault(x => x.Id == id);

            //result.FirstName = updatedStaff.FirstName;

            //result.LastName = updatedStaff.LastName;

            //result.Position = updatedStaff.Position;

            //result.Qualification = updatedStaff.Qualification;

            //result.Salary = updatedStaff.Salary;

            _dbContext.SaveChanges();

            //return updatedStaff;

        }
    }
}
