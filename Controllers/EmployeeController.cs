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

        [HttpPost]
        public IActionResult Post(Employee employee) {
            this.employees.Add(employee);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id, Employee employee) {
            var foundEmployee = this.employees.Find(emp => emp.Id == id);
            if(foundEmployee == null){
                return NotFound();
            }
            foundEmployee.Id = employee.Id;
            foundEmployee.Name = employee.Name;
            foundEmployee.Email = employee.Email;
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id) {
            var index = this.employees.FindIndex(emp => emp.Id == id);
            if(index < 0){
                return NotFound();
            }
            this.employees.RemoveAt(index);
            return Ok();
        }

    }
}