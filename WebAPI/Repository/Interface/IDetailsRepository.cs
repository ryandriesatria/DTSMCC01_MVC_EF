using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Models.ViewModels;

namespace WebAPI.Repository.Interface
{
    interface IDetailsRepository
    {
        List<DetailsViewModel> Get();
        DetailsViewModel Get(int id);
        int Post(DetailsViewModel detail);
        int Put(int id, DetailsViewModel detail);
        int Delete(int id);
    }
}
