using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagement.Entity;
using HospitalManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalRepository _hospitalRepository;

        public HospitalController(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }
       

        // GET: api/<PracticeController>
        [HttpGet]
        public IEnumerable<Hospital> GetAll()
        {
            return _hospitalRepository.GetAll();
        }

      
        // GET api/<PracticeController>/5
      
        [HttpGet("{id}")]
        public Hospital Get(int id)
        {
            return _hospitalRepository.Get(id);
        }

      

        // POST api/<PracticeController>
        [HttpPost("registration")]
        public IActionResult Add([FromBody] Hospital hospital)
        {
            try
            {
                if (hospital == null)
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable);
                }
                if (_hospitalRepository.GetAll().Any(r => r.HospitalName == hospital.HospitalName &&
                     r.Email == hospital.Email))
                {
                    return Content("Hospital already exist");
                }
                else
                {
                    _hospitalRepository.Add(hospital);
                    return Content("Hospital registration successful");
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
           
            
        }

        // PUT api/<PracticeController>/5
        [HttpPut("UpdatePractice")]
        public IActionResult Update([FromBody] Hospital hospital)
        {
            try
            {
                if (hospital == null)
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable);
                }
                _hospitalRepository.Update(hospital);
                return Content("Hospital update successful");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }                   

        }

        // DELETE api/<PracticeController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _hospitalRepository.Delete(id);
        }
    }
}
