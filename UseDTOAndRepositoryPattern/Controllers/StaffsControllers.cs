using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseDTOAndRepositoryPattern.Data_Access_Layer.Abstractions;
using UseDTOAndRepositoryPattern.DTOs.StaffsDTos;
using UseDTOAndRepositoryPattern.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UseDTOAndRepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsControllers : ControllerBase
    {
        public StaffsControllers(IStaffsRepository staffsRepo, IMapper mapper)
        {
            _staffsRepo = staffsRepo;

            _mapper = mapper;
        }

        private readonly IMapper _mapper;

        private readonly IStaffsRepository _staffsRepo;

        // GET: api/<StaffsControllers>
        [HttpGet]
        public IEnumerable<StaffReadDTO> Get()
        {
           var result =  _staffsRepo.GetAll();

            var value = _mapper.Map<IEnumerable<StaffReadDTO>>(result);

            return value;
        }

        // GET api/<StaffsControllers>/5
        [HttpGet("{id}")]
        public StaffReadDTO Get(int id)
        {
           var result = _staffsRepo.Get(id);

            var value = _mapper.Map<StaffReadDTO>(result);

            return value;
        }

        // POST api/<StaffsControllers>
        [HttpPost]
        public void Post([FromBody] StaffCreateDTO newStaff)
        {
            var result = _mapper.Map<Staff>(newStaff);

            _staffsRepo.Create(result);
        }

        // PUT api/<StaffsControllers>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] StaffUpdateDTO updatedStaff)
        {
            var result = _staffsRepo.Get(id);
             
            var value = _mapper.Map(updatedStaff, result);

            _staffsRepo.Update(result);
        }

        //PATCH api/StaffsController/{id}
        [HttpPatch("{id}")]
        public ActionResult Patch(int id, JsonPatchDocument<StaffUpdateDTO> patchDoc)
        {
            var result = _staffsRepo.Get(id);

            if(result == null)
            {
                return NotFound();
            }
            else
            {
                var documentToPatch = _mapper.Map<StaffUpdateDTO>(result);

                patchDoc.ApplyTo(documentToPatch, ModelState);

                if (!TryValidateModel(documentToPatch))
                {
                    return ValidationProblem(ModelState);
                }
                else
                {
                    _mapper.Map(documentToPatch, result);

                    _staffsRepo.Update(result);
                }

                return NoContent();
            }
        }

        // DELETE api/<StaffsControllers>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _staffsRepo.Delete(id);
        }
    }
}
