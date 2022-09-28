using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModels
{
    public class DetailsViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int MasterId { get; set; }
        public int Quantity { get; set; }
    }
}
