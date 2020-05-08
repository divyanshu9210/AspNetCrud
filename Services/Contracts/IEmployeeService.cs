using System.Collections.Generic;
using AspNetCrud.Models;

namespace AspNetCrud.Services.Contracts {
    public interface IEmployeeService
    {
        /// <summary>
        /// Get all Employees
        /// </summary>
        /// <returns></returns>
        List<Employee> Get();

        /// <summary>
        /// Get Employee based on a id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee Get(int id);

        /// <summary>
        /// Insert an employee
        /// </summary>
        /// <param name="employee"></param>
        void Post(Employee employee);
    }
}