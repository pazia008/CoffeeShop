using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using CoffeeShop.Models;

namespace CoffeeShop.Repositories
{
    public class CoffeeRepo : ICoffeeRepo
    {

        private readonly string _connectionString;
        public CoffeeRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection Connection
        {
            get { return new SqlConnection(_connectionString); }
        }


        public List<Coffee> GetAllCoffees()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, Title, BeanVarietyId
                        FROM Coffee
                    ";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Coffee> coffees = new List<Coffee>();
                    while (reader.Read())
                    {
                        Coffee coffee = new Coffee
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            BeanVarietyId = reader.GetInt32(reader.GetOrdinal("BeanVarietyId"))

                        };

                        coffees.Add(coffee);
                    }

                    reader.Close();

                    return coffees;
                }
            }
        }


        public void AddCoffee(Coffee coffee)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO Coffee (Title, BeanVarietyId )
                    OUTPUT INSERTED.ID
                    VALUES (@title, @beanVarietyId);
                ";

                    cmd.Parameters.AddWithValue("@title", coffee.Title);
                    cmd.Parameters.AddWithValue("@beanVarietyId", coffee.BeanVarietyId);
                    int id = (int)cmd.ExecuteScalar();

                    coffee.Id = id;
                }
            }
        }



    }
}
