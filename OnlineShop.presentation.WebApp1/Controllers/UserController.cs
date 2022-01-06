 using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Business;
using OnlineShop.Core.Models;
using OnlineShop.presentation.WebApp1.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.presentation.WebApp1.Controllers
{
    public class UserController : Controller
    {
        private readonly UserDomain userDomain;
        private readonly IMapper mapper;

        public UserController(UserDomain userDomain, IMapper mapper)
        {
            this.userDomain = userDomain;
            this.mapper = mapper;
        }
        // GET: UserController
        public async Task<ActionResult> Index()
        {
            var listCore = await this.userDomain.GetAllAsync();
            var listVm = this.mapper.Map<IEnumerable<UserListViewModel>>(listCore);
            return View(listVm);
        }

        // GET: UserController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var userCore = await this.userDomain.GetByIdIncludeAsync(id);
            var userVm = this.mapper.Map<UserDetailsViewModel>(userCore);
            return View(userVm);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserListViewModel model)
        {
            try
            {
                await this.userDomain.CreateAsync(this.mapper.Map<UserCore>(model));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var userCore = await this.userDomain.GetByIdAsync(id);

            return View(this.mapper.Map<UserListViewModel>(userCore));
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserListViewModel model)
        {
            try
            {
                await this.userDomain.UpdateAsync(this.mapper.Map<UserCore>(model));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: UserController/Delete/5
        public async Task< ActionResult> Delete(int id)
        {
            var userCore = await this.userDomain.GetByIdAsync(id);
            return View(this.mapper.Map<UserListViewModel>(userCore));
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, UserListViewModel model)
        {
            try
            {
                await this.userDomain.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
