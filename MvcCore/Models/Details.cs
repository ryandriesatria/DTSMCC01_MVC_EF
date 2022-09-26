using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Models
{
    public class Details
    {
        [Key]
        public int Id { get; set; }

        public Products Products { get; set; }
        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public Masters Masters{ get; set; }
        [ForeignKey("Masters")]
        public int MasterId { get; set; }
        public int Quantity { get; set; }
    }
}
