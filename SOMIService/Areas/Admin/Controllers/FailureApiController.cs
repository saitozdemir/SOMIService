using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOMIService.Data;
using SOMIService.Extensions;
using SOMIService.Models.ComplexTypes;
using SOMIService.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOMIService.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(Roles ="Admin,Operator")]
    public class FailureApiController : Controller
    {
        private readonly MyContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public FailureApiController(MyContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Get(DataSourceLoadOptions loadOptions)
        {
            var data = _dbContext.FailureLoggings
                .Include(x => x.ApplicationUser)
                .OrderByDescending(x => x.CreatedDate)
                .ToList();
            return Ok(DataSourceLoader.Load(data, loadOptions));
        }

        public IActionResult GetTeknisyenLookup(DataSourceLoadOptions loadoptions)
        {
            var data = _dbContext.Users.ToList();
            var model = new List<ApplicationUser>();

            foreach (var user in data)
            {
                if (_userManager.IsInRoleAsync(user, RoleModels.Technician).Result)
                {
                    model.Add(user);
                }
            }
            return Ok(DataSourceLoader.Load(model, loadoptions));
        }
        public IActionResult GetOperatorLookup(DataSourceLoadOptions loadoptions)
        {
            var data = _dbContext.Users.ToList();
            var model = new List<ApplicationUser>();

            foreach (var user in data)
            {
                if (_userManager.IsInRoleAsync(user, RoleModels.Operator).Result)
                {
                    model.Add(user);
                }
            }
            return Ok(DataSourceLoader.Load(model, loadoptions));
        }

    }
}
