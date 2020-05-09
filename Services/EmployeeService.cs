using System.Collections.Generic;
using AspNetCrud.Models;
using AspNetCrud.Providers.Contracts;
using AspNetCrud.Services.Contracts;

namespace AspNetCrud.Services {
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeProvider _provider;
        public EmployeeService(IEmployeeProvider provider)
        {
            this._provider = provider;
        }
        public List<Employee> Get()
        {
            return _provider.Get();
        }

        public Employee Get(int id){
            return _provider.Get(id);
        }

        public void Post(Employee employee)
        {
            _provider.Post(employee);
        }

        public void Put(int id, Employee employee)
        {
            _provider.Put(id, employee);
        }

        public void Delete(int id){
            _provider.Delete(id);
        }
    }
}