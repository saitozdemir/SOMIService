using SOMIService.Models;
using SOMIService.Models.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOMIService.Services.Email
{
    public interface IEmailSender
    {
        Task SendAsync(EmailMessage message);
    }
}
