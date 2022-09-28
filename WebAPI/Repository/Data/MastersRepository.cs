using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Context;
using WebAPI.Models;
using WebAPI.Repository.Interface;

namespace WebAPI.Repository.Data
{
    public class MastersRepository : IMastersRepository
    {
        private readonly ApplicationDbContext _context;
        public MastersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Delete(int id)
        {
            var data = _context.Masters.Find(id);
            _context.Masters.Remove(data);
            var result = _context.SaveChanges();
            return result;
        }

        public List<Masters> Get()
        {
            var data = _context.Masters.ToList();
            return data;
        }

        public Masters Get(int id)
        {
            var data = _context.Masters.Find(id);
            return data;
        }

        public int Post(Masters master)
        {
            _context.Masters.Add(master);
            var result = _context.SaveChanges();
            return result;
        }

        public int Put(int id, Masters master)
        {
            var data = Get(id);
            data.TransactionDate = master.TransactionDate;
            _context.Masters.Update(data);
            var result = _context.SaveChanges();
            return result;
        }
    }
}
