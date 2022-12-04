using NorthWind.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace NorthWind.Repostories
{
    public class ProductRepostory : RepostoryBase
    {

        public static List<Product> RepoProducts { get; set; }
        public static void GetAllProducts()
        {
            var products = new List<Product>();
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "select * from Products";
                SqlCommand cmd = new SqlCommand(query, conn);

                using (var reader =   cmd.ExecuteReader())
                {
                    while (  reader.Read())
                    {
                        string Name;
                        decimal Price;
                        int Id;
                        Id = reader.GetFieldValue<int>(0);
                        Name = reader.GetFieldValue<string>(1);
                        Price = reader.GetFieldValue<decimal>(5);

                        Product p = new Product
                        {
                            Name = Name,
                            Price = Price,
                            Id = Id,
                        };
                        products.Add(p);
                    }
                }
            }
            RepoProducts = products;

        }

        public static void DeleteProductById(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = $@"DELETE FROM Products 
                                  WHERE ProductID=@id";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }

            }
        }

    }
}
