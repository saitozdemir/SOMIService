using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOMIService.ViewModels
{
    public class OperatorFailureViewModel
    {
        public string Message { get; set; }
        public IdentityRole FromWhom { get; set; }
        public DateTime CreatedDate { get; set; }
        public int FailureId { get; set; }
    }
}
