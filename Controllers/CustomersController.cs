using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace to_do_list.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly string _connectionString;

        public CustomersController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";
        }

        [HttpGet] 
        public IActionResult GetAll()
        {
            var customers = new List<object>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Customers ORDER BY id DESC";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                Email = reader.GetString(3)
                            });
                        }
                    }
                }
            }
            return Ok(customers);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, ex.Message);
            }
        }
    }
}