using System.Data.SqlClient;

namespace AspNetCrud.Models {
    public class Employee {
        public int Id { get ; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}