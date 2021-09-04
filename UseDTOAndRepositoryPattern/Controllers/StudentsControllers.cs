using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseDTOAndRepositoryPattern.Data_Access_Layer.Abstractions;
using UseDTOAndRepositoryPattern.DTOs.StudentsDTOs;
using UseDTOAndRepositoryPattern.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UseDTOAndRepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsControllers : ControllerBase
    {
        public StudentsControllers(IStudentRepository studentRepo, IMapper mapper)
        {
            _studentRepo = studentRepo;

            _mapper = mapper;
        }

        private readonly IMapper _mapper;

        private readonly IStudentRepository _studentRepo;

        // GET: api/<StudentsControllers>
        [HttpGet]
        public IEnumerable<StudentReadDTO> Get()
        {
            var result = _studentRepo.GetAll();

            var value = _mapper.Map < IEnumerable < StudentReadDTO >>(result);

            return value;
        }

        // GET api/<StudentsControllers>/5
        [HttpGet("{id}")]
        public StudentReadDTO Get(int id)
        {
            var result = _studentRepo.Get(id);

            var value = _mapper.Map<StudentReadDTO>(result);

            return value;
        }

        // POST api/<StudentsControllers>
        [HttpPost]
        public void Post([FromBody] StudentCreateDTO newStudent)
        {
            var result = _mapper.Map<Student>(newStudent);

            _studentRepo.Create(result);

        }

        // PUT api/<StudentsControllers>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] StudentUpdateDTO updatedStudent)
        {
            var result = _studentRepo.Get(id);

            var value = _mapper.Map(updatedStudent, result);

            _studentRepo.Update(result);
        }


        //PATCH api/<StudentsController>/{id}
        [HttpPatch("{id}")]
        public ActionResult Patch(int id, JsonPatchDocument<StudentUpdateDTO> patchDoc)
        {
            var result = _studentRepo.Get(id);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                var documentToPatch = _mapper.Map<StudentUpdateDTO>(result);

                patchDoc.ApplyTo(documentToPatch, ModelState);

                if (!TryValidateModel(documentToPatch))
                {
                    return ValidationProblem(ModelState);
                }
                else
                {
                    _mapper.Map(documentToPatch, result);

                    _studentRepo.Update(result);
                }

                return NoContent();
            }
        }

        // DELETE api/<StudentsControllers>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _studentRepo.Delete(id);
        }
    }
}
