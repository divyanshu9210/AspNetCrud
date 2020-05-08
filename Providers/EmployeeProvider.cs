using System.Collections.Generic;
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
            using(var connection = new SqlConnection(this._connectionString)){
                connection.Open();
                using(SqlCommand cmd = new SqlCommand()){
                    cmd.Connection = connection;
                    cmd.CommandText = "Select [Id], [Name], [Email] from [Employees]";
                    using(var reader = cmd.ExecuteReader()){
                        while(reader.Read()){
                            result.Add(ParseEntity(reader));
                        }
                    }
                    return result;
                }
            }            
        }

        public Employee Get(int id)
        {
            using(var connection = new SqlConnection(this._connectionString)){
                connection.Open();
                using(SqlCommand cmd = new SqlCommand()){
                    cmd.Connection = connection;
                    cmd.CommandText = "Select [Id], [Name], [Email] from [Employees] where Id = @Id";
                    cmd.Parameters.Add(new SqlParameter("@Id", id));
                    using(var reader = cmd.ExecuteReader()){
                        while(reader.Read()){
                            return ParseEntity(reader);
                        }
                        return null;
                    }
                }
            }  
        }

        public void Post(Employee employee){
            using(var connection = new SqlConnection(_connectionString)){
                connection.Open();
                using(var cmd = new SqlCommand()){
                    cmd.Connection = connection;
                    cmd.CommandText = "Insert into Employees(Name, Email) values (@Name, @Email)";
                    cmd.Parameters.Add(new SqlParameter("@Name", employee.Name));
                    cmd.Parameters.Add(new SqlParameter("@Email", employee.Email));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private Employee ParseEntity(SqlDataReader reader){
            Employee employee = new Employee();
            int index;
            object value;
            index = reader.GetOrdinal("Id");
            value = reader.GetValue(index);
            employee.Id = (int)value;
            index = reader.GetOrdinal("Name");
            value = reader.GetValue(index);
            employee.Name = (string)value;
            index = reader.GetOrdinal("Email");
            value = reader.GetValue(index);
            employee.Email = (string)value;
            return employee;
        }
    }
}