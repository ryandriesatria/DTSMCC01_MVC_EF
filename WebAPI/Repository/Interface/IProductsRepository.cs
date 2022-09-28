using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository.Interface
{
    interface IProductsRepository
    {
        List<Products> Get();
        Products Get(int id);
        int Post(Products product);
        int Put(int id, Products product);
        int Delete(int id);
    }
}
