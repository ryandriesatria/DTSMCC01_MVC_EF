using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Masters
    {
        [Key]
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
