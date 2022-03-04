using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SOMIService.Data;
using SOMIService.Extensions;
using SOMIService.Models;
using SOMIService.Models.Identity;
using SOMIService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOMIService.Controllers
{
    public class CustomerController : Controller
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly MyContext _dbContext;

        public CustomerController(MyContext context, IMapper mapper, UserManager<ApplicationUser> userManager,MyContext dbContext)
        {
            _mapper = mapper;
            _context = context;
            _userManager=userManager;
            _dbContext = dbContext;
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetFailureLoggingByUserId()
        {

            var user = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            ViewBag.UserName = user.UserName;
            ViewBag.Email = user.Email;
            var userFailureLogging = _context.FailureLoggings
            .OrderByDescending(x => x.CreatedDate)
            .Where(x => x.UserId == user.Id)
            .ToList()
            .Select(x => _mapper.Map<CustomerFailureViewModel>(x))
            .ToList();

            return View(userFailureLogging);
           
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddFailureLogging()
        {
            var user = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            if (user == null) return BadRequest(string.Empty);
            ViewBag.UserName = user.UserName;
            ViewBag.Email = user.Email;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFailureLogging(CustomerFailureViewModel model)
        {
            //var data = _mapper.Map<FailureLogging>(model);
            var data = new FailureLogging()
            {

                UserId = HttpContext.GetUserId(),
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                Description = model.Description,
                CreatedDate = model.CreatedDate,
                FaultIsFixxed=model.FaultIsFixxed


            };

            _dbContext.FailureLoggings.Add(data);
            _dbContext.SaveChanges();

            return RedirectToAction("Index","Home");
        }


    }
}
