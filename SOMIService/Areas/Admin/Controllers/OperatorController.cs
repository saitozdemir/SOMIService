using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SOMIService.Data;
using SOMIService.Extensions;
using SOMIService.Models.Enums;
using SOMIService.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOMIService.Areas.Admin.Controllers
{
    public class OperatorController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly MyContext _dbContext;

        public OperatorController(MyContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var data = _dbContext.FailureLoggings
                .OrderByDescending(x => x.CreatedDate)
                .ToList();

            return View(data);
        }
        [HttpGet]
        public async Task<ActionResult> FailureAccept(int id)
        {
            var opearator = await _userManager.FindByIdAsync(HttpContext.GetUserId());

            var failureRecord = _dbContext.FailureLoggings
               .FirstOrDefault(x => x.FailureLoggingId == id);
            if (failureRecord == null)
            {
                RedirectToAction("Index", "Operator");
            }
            else
            {
                failureRecord.OperatorId = opearator.Id;
                failureRecord.OperationTime = DateTime.Now;
                failureRecord.OperationStatus = OperationStatuses.Pending;
                _dbContext.FailureLoggings.Update(failureRecord);
                _dbContext.SaveChanges();
                RedirectToAction("Index", "Operator");
            }
            return RedirectToAction("Index", "Operator");
        }

        public IActionResult FailureList()
        {
            var data = _dbContext.FailureLoggings
                .OrderByDescending(x => x.OperationTime)
                .ToList();

            return View(data);
        }
    }
}

