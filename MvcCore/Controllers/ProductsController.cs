using Microsoft.AspNetCore.Mvc;
using MvcCore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Controllers
{
    public class ProductsController : Controller
    {
        SqlConnection sqlConnection;

        string connectionString = "Data Source=DESKTOP-BMTQ0KM;Initial Catalog=Toko;User ID=ryan;Password=123456;";
        public IActionResult Index(int id)
        {
            string query;
            if (id == 0)
            {
                query = "SELECT * FROM Products";
            }
            else
            {
                query = $"SELECT * FROM Products WHERE id = {id}";
            }

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            List<Products> products = new List<Products>();
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Products product = new Products();
                            product.Id = Convert.ToInt32(sqlDataReader[0]);
                            product.Name = sqlDataReader[1].ToString();
                            product.Stock = Convert.ToInt32(sqlDataReader[2]);
                            product.Price = Convert.ToInt32(sqlDataReader[3]);

                            products.Add(product);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(products);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Products product)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = "INSERT INTO Products " +
                        "(name, stock, price) " +
                        $"VALUES ('{product.Name}', {product.Stock}, {product.Price})";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine($"Produk berhasil dibuat!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return RedirectToAction("Index");
            }
        }

        //GET
        public IActionResult Edit(int id)
        {
            string query = $"SELECT * FROM Products WHERE id = {id}";

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            Products product = new Products();
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            product.Id = Convert.ToInt32(sqlDataReader[0]);
                            product.Name = sqlDataReader[1].ToString();
                            product.Stock = Convert.ToInt32(sqlDataReader[2]);
                            product.Price = Convert.ToInt32(sqlDataReader[3]);

                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(product);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Products product)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = "UPDATE Products SET " +
                        $"name = '{product.Name}', " +
                        $"stock = {product.Stock}, " +
                        $"price = {product.Price} " +
                        $"WHERE id = {product.Id}";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine($"Produk berhasil diedit!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return View();
            }
        }

        //GET
        public IActionResult Delete(int id)
        {
            string query = $"SELECT * FROM Products WHERE id = {id}";

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            Products product = new Products();
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            product.Id = Convert.ToInt32(sqlDataReader[0]);
                            product.Name = sqlDataReader[1].ToString();
                            product.Stock = Convert.ToInt32(sqlDataReader[2]);
                            product.Price = Convert.ToInt32(sqlDataReader[3]);

                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(product);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Products product)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = "DELETE FROM Products " +
                        $"WHERE id = {product.Id}";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine($"Product berhasil dihapus!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return View();
        }

        //GET
        public IActionResult Details(int id)
        {
            string query = $"SELECT * FROM Products WHERE id = {id}";

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            Products product = new Products();
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            product.Id = Convert.ToInt32(sqlDataReader[0]);
                            product.Name = sqlDataReader[1].ToString();
                            product.Stock = Convert.ToInt32(sqlDataReader[2]);
                            product.Price = Convert.ToInt32(sqlDataReader[3]);

                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(product);
        }

        
    }
}

