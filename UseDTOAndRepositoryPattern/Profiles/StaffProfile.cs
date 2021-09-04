using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseDTOAndRepositoryPattern.DTOs.StaffsDTos;
using UseDTOAndRepositoryPattern.Models;

namespace UseDTOAndRepositoryPattern.Profiles
{
    public class StaffProfile : Profile
    {
        public StaffProfile()
        {
            CreateMap<Staff, StaffReadDTO>();
            CreateMap<StaffCreateDTO, Staff>();
            CreateMap<StaffUpdateDTO, Staff>();
            CreateMap<Staff, StaffUpdateDTO>();
        }
    }
}
