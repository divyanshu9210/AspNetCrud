using System.Collections.Generic;
using AspNetCrud.Models;

namespace AspNetCrud.Providers.Contracts {
    public interface IEmployeeProvider 
    {
        /// <summary>
        /// Get all Employees
        /// </summary>
        /// <returns></returns>
        List<Employee> Get();

        /// <summary>
        /// Get Employee based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee Get(int id);
    }
}