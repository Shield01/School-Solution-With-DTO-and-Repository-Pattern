using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseDTOAndRepositoryPattern.Data_Access_Layer.Abstractions;
using UseDTOAndRepositoryPattern.Models;

namespace UseDTOAndRepositoryPattern.Data_Access_Layer.Concrete_Implementations
{
    public class StudentsRepository : IStudentRepository
    {

        public StudentsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly ApplicationDbContext _dbContext;

        public void Create(Student newStudent)
        {
            _dbContext.Add(newStudent);
            _dbContext.SaveChanges();
        }

        public Student CreateAndReturn(Student newStudednt)
        {
            _dbContext.Add(newStudednt);
            _dbContext.SaveChanges();
            return (newStudednt);
        }

        public void Delete(int id)
        {
            var result = _dbContext.Students.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(result);
            _dbContext.SaveChanges();
        }

        public Student Get(int id)
        {
            var result = _dbContext.Students.FirstOrDefault(x => x.Id == id);
            return (result);
        }

        public IEnumerable<Student> GetAll()
        {
            var result = _dbContext.Students;
            return result;
        }

        public void Update(Student updatedStudent)
        {
            //var result = _dbContext.Students.FirstOrDefault(x => x.Id == id);

            //result.FirstName = updatedStudent.FirstName;

            //result.LastName = updatedStudent.LastName;

            //result.PhoneNumber = updatedStudent.PhoneNumber;

            //result.StateOfOrigin = updatedStudent.StateOfOrigin;

            //result.Age = updatedStudent.Age;

            //result.EmailAddress = updatedStudent.EmailAddress;

            _dbContext.SaveChanges();

            //return (updatedStudent);
        }
    }
}
