using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AspNetCrud.Models;

namespace AspNetCrud.Controllers {

    [Route("{controller}")]
    public class EmployeeController : ControllerBase {

        private List<Employee> employees = new List<Employee>() {
                new Employee() { Id = 1, Name = "Aman", Email = "amanbarnwalce@gmail.com" },
                new Employee() { Id = 2, Name = "Ankit", Email = "ankit@gmail.com" },
                new Employee() { Id = 3, Name = "Divya", Email = "divya@yahoo.com" }
            };
        
        [HttpGet]
        public IActionResult Get() {
            return Ok(this.employees);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id) {
            var employee = employees.Find(emp => emp.Id == id);
            if(employee == null) {
                return NotFound();
            }
            else {
                return Ok(employee);
            }
        }
    }
}