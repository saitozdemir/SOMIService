using AutoMapper;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SOMIService.Data;
using SOMIService.Extensions;
using SOMIService.Models.Identity;
using SOMIService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOMIService.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly MyContext _dbcontext;
        private readonly IMapper _mapper;
        public ManageController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, MyContext dbcontext, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbcontext = dbcontext;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Users()
        {
            var users = _userManager.Users;
            return View(users);
        }
        public async Task<IActionResult> Details(string? id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new UserDetailViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.UserName,
                CreatedDate = user.CreatedDate,
                Email = user.Email,
                IsActive = user.EmailConfirmed,
                UserRoles = userRoles,
                RoleNames = string.Join(',', userRoles)
            };

            var roleList = GetRoleList();
            foreach (var role in roleList)
            {
                if (userRoles.Contains(role.Text))
                {
                    role.Selected = true;
                }
            }

            ViewBag.Roles = roleList;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(string? id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new UserDetailViewModel()
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                UserName = user.UserName,
                UserRoles = userRoles
            };

            var roleList = GetRoleList();
            foreach (var role in roleList)
            {
                if (userRoles.Contains(role.Text))
                {
                    role.Selected = true;
                }
            }
            ViewBag.Roles = roleList;
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> Update(UserDetailViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null) return NotFound();

            //Kullanıcı Update işlemleri
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.UserName = model.UserName;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, ModelState.ToFullErrorString());
            }

            //Kullanıcı Rol işlemleri
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                var roleRemove = await _userManager.RemoveFromRoleAsync(user, role);
            }
            var SelectedRole = await _roleManager.FindByIdAsync(model.SelectedRoleId);
            var roleAdd = await _userManager.AddToRoleAsync(user, SelectedRole.Name);

            if (!roleAdd.Succeeded)
            {
                ModelState.AddModelError(string.Empty, ModelState.ToFullErrorString());
            }

            TempData["Mesaj"] = "Güncelleme işlemi başarılı";
            return LocalRedirect($"~/admin/manage/update/{user.Id}");

        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, ModelState.ToFullErrorString());
            }

            TempData["Mesaj"] = "Silme işlemi başarılı";
            return LocalRedirect($"~/admin/manage/users");

        }
        private List<SelectListItem> GetRoleList()
        {
            var roles = _roleManager.Roles;
            var rolList = new List<SelectListItem>();

            foreach (var role in roles)
            {
                rolList.Add(new SelectListItem(role.Name, role.Id.ToString()));
            }
            return rolList;
        }

        public IActionResult SubscriptionTypes()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetFailureLogging()
        {

            //var data = _dbcontext.FailureLoggings
            //    .Include(x => x.ApplicationUser)
            //    .OrderByDescending(x => x.CreatedDate)
            //    .ToList();

            return View();
            //catch (Exception)
            //{
            //    TempData["Model"] = new ErrorViewModel()
            //    {
            //        Text = $"Bir hata oluştu {ex.Message}",
            //        ActionName = "Index",
            //        ControllerName = "Home",
            //        ErrorCode = 500
            //    };
            //    return RedirectToAction("Error", "Home");
            //}
        }

        ////[HttpGet]
        ////public IActionResult GetFailureLoggingData(DataSourceLoadOptions loadOptions)
        ////{
        ////    var data = _dbcontext.FailureLoggings;
        ////    return Ok(DataSourceLoader.Load(data, loadOptions));
        ////}
    }
}
