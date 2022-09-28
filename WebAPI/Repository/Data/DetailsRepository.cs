using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Context;
using WebAPI.Models;
using WebAPI.Models.ViewModels;
using WebAPI.Repository.Interface;

namespace WebAPI.Repository.Data
{
    public class DetailsRepository : IDetailsRepository
    {
        private readonly ApplicationDbContext _context;
        public DetailsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Delete(int id)
        {
            var data = _context.Details.Find(id);
            _context.Details.Remove(data);
            var result = _context.SaveChanges();
            return result;
        }

        public List<Details> Get()
        {
            var data = _context.Details.ToList();

            return data;
        }

        public Details Get(int id)
        {
            var data = _context.Details.Find(id);
            return data;
        }

        public int Post(DetailsViewModel detail)
        {
            _context.Details.Add(new Details
            {
                Id = detail.Id,
                ProductId = detail.ProductId,
                MasterId = detail.MasterId,
                Quantity = detail.Quantity
            });
            var result = _context.SaveChanges();
            return result;
        }

        public int Put(int id, DetailsViewModel detail)
        {
            var data = _context.Details.Find(id);
            data.MasterId = detail.MasterId;
            data.ProductId = detail.ProductId;
            data.Quantity = detail.Quantity;
            _context.Details.Update(data);
            var result = _context.SaveChanges();
            return result;
        }
    }
}
