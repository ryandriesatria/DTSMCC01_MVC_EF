using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Context;
using WebAPI.ViewModels;
using WebAPI.Models;

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
            else if (data != null && !ValidatePassword(login.Password, data.User.Password))
                return null;

            return new ResponseLogin
            {
                Id = data.UserId,
                Email = data.User.Employee.Email,
                FullName = data.User.Employee.FullName,
                Role = data.Role.Name

            };
        }

        //Register, if successful redirect to login.
        public ResponseLogin Register(Register register)
        {

            _context.Employee.Add(new Employee
            {
                FullName = register.FullName,
                Email = register.Email

            });

            var result = _context.SaveChanges();

            if (result > 0)
            {
                //Get employeeId from registered user
                int id = _context.Employee.Where(x => x.Email == register.Email).Select(x => x.Id).FirstOrDefault();

                //Insert registered user to table User and UserRole
                _context.User.Add(new User
                {
                    Id = id,
                    Password = HashPassword(register.Password)
                });
                _context.UserRole.Add(new UserRole
                {
                    UserId = id,
                    RoleId = _context.Role.Where(x => x.Name == register.Role).Select(x => x.Id).FirstOrDefault()
                });

                var result2 = _context.SaveChanges();

                //Login process
                if (result2 > 1)
                {
                    var data = Login(new Login
                    {
                        Email = register.Email,
                        Password = register.Password
                    });

                    return data;
                }
            }

            return null;
        }

        //Change Password
        public int ChangePassword(ChangePassword changePassword)
        {
            var employee = _context.Employee.Where(x => x.Email == changePassword.Email).FirstOrDefault();

            if (employee != null)
            {
                var user = _context.User.Where(x => x.Id == employee.Id).FirstOrDefault();

                if (user != null && ValidatePassword(changePassword.OldPassword, user.Password))
                {
                    user.Password = HashPassword(changePassword.NewPassword);
                    _context.User.Update(user);
                    var result = _context.SaveChanges();

                    if(result > 0)
                    {
                        return 1;
                    }
                }


            }
            return 0;
        }

        //ForgotPassword
        public int ForgotPassword(ForgotPassword forgotPassword)
        {
            var employee = _context.Employee.Where(x => x.Email == forgotPassword.Email).FirstOrDefault();

            if (employee != null)
            {
                var user = _context.User.Where(x => x.Id == employee.Id).FirstOrDefault();

                if (user != null)
                {
                    user.Password = HashPassword(forgotPassword.NewPassword);
                    _context.User.Update(user);
                    var result = _context.SaveChanges();

                    if (result > 0)
                    {
                        return 1;
                    }
                }


            }
            return 0;
        }


        private string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
        }

        private bool ValidatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }
    }
}
