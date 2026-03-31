using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient; 
using Microsoft.Extensions.Configuration; 

namespace to_do_list.Components.Pages.Customers
{
    public class Index : PageModel
    {
        private readonly IConfiguration _configuration;

        public Index(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<CustomerInfo> CustomersList { get; set; } = [];
        public void OnGet()
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection") ?? "";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Customers ORDER BY id DESC";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerInfo customer = new CustomerInfo
                                {
                                    Id = reader.GetInt32(0),
                                    FirstName = reader.GetString(1),
                                    LastName = reader.GetString(2),
                                    Email = reader.GetString(3),
                                    Phone = reader.GetString(4),
                                    Address = reader.GetString(5),
                                    Company = reader.GetString(6),
                                    Notes = reader.GetString(7),
                                    CreatedAt = reader.GetDateTime(8)
                                };

                                CustomersList.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public class CustomerInfo
        {
            public int Id { get; set; }
            public string FirstName { get; set; } = "";
            public string LastName { get; set; } = "";
            public string Email { get; set; } = "";
            public string Phone { get; set; } = "";
            public string Address { get; set; } = "";
            public string Company { get; set; } = "";
            public string Notes { get; set; } = "";
            public DateTime CreatedAt { get; set; }
        }
    }
}