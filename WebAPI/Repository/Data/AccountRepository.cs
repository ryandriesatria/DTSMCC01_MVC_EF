using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Context;
using WebAPI.ViewModels;

namespace WebAPI.Repository.Data
{
    public class AccountRepository
    {
        private readonly ApplicationDbContext _context;
        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResponseLogin Login(Login login)
        {

            var data = _context.UserRole.
                Include(x => x.User.Employee).
                Include(x => x.User).
                Include(x => x.Role).
                Where(x => x.User.Employee.Email == login.Email).FirstOrDefault();

            if (data == null)
                return null;
            else if (data != null && !login.Password.Equals(data.User.Password))
                return null;

            return new ResponseLogin
            {
                Id = data.UserId,
                Email = data.User.Employee.Email,
                FullName = data.User.Employee.FullName,
                Role = data.Role.Name
                
            };
        }
    }
}
