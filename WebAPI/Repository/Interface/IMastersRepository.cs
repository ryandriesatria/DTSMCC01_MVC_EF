using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository.Interface
{
    interface IMastersRepository
    {
        List<Masters> Get();
        Masters Get(int id);
        int Post(Masters masters);
        int Put(int id, Masters masters);
        int Delete(int id);
    }
}
