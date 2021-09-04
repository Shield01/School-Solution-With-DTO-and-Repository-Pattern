using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseDTOAndRepositoryPattern.Models;

namespace UseDTOAndRepositoryPattern.Data_Access_Layer.Abstractions
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();

        Student Get(int id);

        void Create(Student newStudent);

        Student CreateAndReturn(Student newStudednt);

        void Update(Student updatedStudent);

        void Delete(int id);
    }
}
