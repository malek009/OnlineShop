using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Business;
using OnlineShop.Core.Models;
using OnlineShop.presentation.WebApp1.Models.Articles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.presentation.WebApp1.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ArticleDomain articleDomain;
        private readonly IMapper mapper;

        public ArticleController(ArticleDomain articleDomain,IMapper mapper)
        {
            this.articleDomain = articleDomain;
            this.mapper = mapper;
        }
        // GET: ArticleController
        public async Task<ActionResult> Index()
        {
            var listCore = await this.articleDomain.GetAllAsync();
            var listVm = this.mapper.Map<IEnumerable<ArticleListViewModel>>(listCore);
            return View(listVm);
        }


        // GET: ArticleController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var artCore = await this.articleDomain.GetByIdAsync(id);
            var artVm = this.mapper.Map<ArticleDetailsViewModel>(artCore);
            return View(artVm);
        }

        // GET: ArticleController/Create
        public async Task<ActionResult>  Create()
        {
            var listCategory = await this.articleDomain.getAllCategoriesAsync();
            List<SelectListItem> listVm = new List<SelectListItem>();
            foreach(var item in listCategory)
            {
                listVm.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }
            var vm = new ArticleFormViewModel { Categories = listVm };
            return View(vm);
        }

      

        // POST: ArticleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<ActionResult> Create(ArticleFormViewModel model)
        {
            try
            {
                await this.articleDomain.CreateAsync(this.mapper.Map<ArticleCore>(model.Article));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

      

        // GET: ArticleController/Edit/5
        public async Task <ActionResult> Edit(int id)
        {
            var listCategory = await this.articleDomain.getAllCategoriesAsync();
            List<SelectListItem> listVm = new List<SelectListItem>();
            foreach (var item in listCategory)
            {
                listVm.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }

            var article = await this.articleDomain.GetByIdAsync(id);
            var va = this.mapper.Map<ArticleDetailsViewModel>(article);
            var vm = new ArticleFormViewModel { Categories = listVm, Article=va };
            return View(vm);
        }

        // POST: ArticleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( ArticleFormViewModel model)
        {
            try
            {
                await this.articleDomain.UpdateAsync(this.mapper.Map<ArticleCore>(model.Article));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: ArticleController/Delete/5
        public async Task< ActionResult> Delete(int id)
        {
            var artCore = await this.articleDomain.GetByIdAsync(id);
            var artVm = this.mapper.Map<ArticleDeleteViewModel>(artCore);
            return View(artVm);
            
        }

        // POST: ArticleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Delete(int id,ArticleDeleteViewModel model)
        {
            try
            {
                await this.articleDomain.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
