using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AspNetCrud.Models;
using AspNetCrud.Providers.Contracts;

namespace AspNetCrud.Providers {
    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly string _connectionString;
        public EmployeeProvider(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public List<Employee> Get()
        {
            List<Employee> result = new List<Employee>();
            SqlConnection connection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Employee;Data Source=DESKTOP-L6PI58P\SQLEXPRESS");
            connection.Open();
            SqlCommand command = new SqlCommand("Select * from Employees");
            command.Connection = connection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet employees = new DataSet();
            adapter.Fill(employees);
            connection.Close();
            foreach(DataTable table in employees.Tables){
                foreach(DataRow row in table.Rows){
                    var employee = new Employee();
                    employee.Id = Convert.ToInt32(row["Id"]); 
                    employee.Name = Convert.ToString(row["Name"]);
                    employee.Email = Convert.ToString(row["Email"]);
                    result.Add(employee);
                }
            }
            return result;
        }

        public Employee Get(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}