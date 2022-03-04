using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SOMIService.Models
{
    public class FailureLoggingPrice
    {
        [Key]
        public int FailureLoggingId { get; set; }
        public string FailureLoggingName { get; set; }
        public decimal FailurePrice { get; set; }
    }
}
