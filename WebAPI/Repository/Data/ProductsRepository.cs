using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Context;
using WebAPI.Models;
using WebAPI.Repository.Interface;

namespace WebAPI.Repository.Data
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Delete(int id)
        {
            var data = _context.Products.Find(id);
            _context.Products.Remove(data);
            var result = _context.SaveChanges();
            return result;
        }

        public List<Products> Get()
        {
            var data = _context.Products.ToList();
            return data;
        }

        public Products Get(int id)
        {
            var data = _context.Products.Find(id);
            return data;
        }

        public int Post(Products product)
        {
            _context.Products.Add(product);
            var result = _context.SaveChanges();
            return result;
        }

        public int Put(int id, Products product)
        {
            var data = Get(id);
            data.Name = product.Name;
            data.Price = product.Price;
            data.Stock = product.Stock;
            _context.Products.Update(data);
            var result = _context.SaveChanges();
            return result;
        }
    }
}
