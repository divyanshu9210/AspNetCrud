using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AspNetCrud.Models;
using AspNetCrud.Services.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace AspNetCrud.Controllers
{

    [Route("{controller}")]
    [Authorize]
    public class EmployeeController : ControllerBase {

        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        private List<Employee> employees = new List<Employee>() {
                new Employee() { Id = 1, Name = "Aman", Email = "amanbarnwalce@gmail.com" },
                new Employee() { Id = 2, Name = "Ankit", Email = "ankit@gmail.com" },
                new Employee() { Id = 3, Name = "Divya", Email = "divya@yahoo.com" }
            };
        
        [HttpGet]
        public IActionResult Get() {
            var employees = this._employeeService.Get();
            return Ok(employees);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id) {
            Employee employee = _employeeService.Get(id);
            if(employee == null) {
                return NotFound();
            }
            else {
                return Ok(employee);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Employee employee) {
            _employeeService.Post(employee);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, [FromBody]Employee employee) {
            _employeeService.Put(id, employee);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id) {
            _employeeService.Delete(id);
            return Ok();
        }

    }
}