using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SOMIService.Data;
using SOMIService.Extensions;
using SOMIService.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOMIService.Areas.Admin.Controllers
{
    public class TechnicianController : Controller
    {
        List<SelectListItem> Technicians = new List<SelectListItem>();

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly MyContext _dbContext;

        public TechnicianController(UserManager<ApplicationUser> userManager, MyContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> getFailureLoggingByTechicianId()
        {
            var technician = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            var FailureLoggingbyTechnicianId = _dbContext.FailureLoggings
                .Where(x => x.TechnicianId == technician.Id)
                .ToList();

            return View(FailureLoggingbyTechnicianId);
        }
    }
}
