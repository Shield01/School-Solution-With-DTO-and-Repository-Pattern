using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseDTOAndRepositoryPattern.DTOs.StudentsDTOs;
using UseDTOAndRepositoryPattern.Models;

namespace UseDTOAndRepositoryPattern.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentReadDTO>();
            CreateMap<StudentCreateDTO, Student>();
            CreateMap<StudentUpdateDTO, Student>();
            CreateMap<Student, StudentUpdateDTO>();
        }
    }
}
