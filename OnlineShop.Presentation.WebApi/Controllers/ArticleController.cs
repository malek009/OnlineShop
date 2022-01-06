using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Business;
using OnlineShop.Core.Models;
using OnlineShop.Presentation.WebApi.Models;
using OnlineShop.Presentation.WebApi.ViewModels.Articles;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Presentation.WebApi.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleDomain articleDomain;
        private IMapper mapper;
        public ArticleController(ArticleDomain articleDomain, IMapper mapper)
        {
            this.articleDomain = articleDomain;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticleViewModel>>> GetAll()
        {
            try
            {
                return this.Ok(this.mapper.Map<IEnumerable<ArticleViewModel>>
                    (await this.articleDomain.GetAllAsync()));
            }
            catch (System.Exception)
            {
                return this.BadRequest();
            }
        }
        [HttpGet]
        public async Task<ActionResult<ArticleViewModel>> GetById(int id)
        {
            return this.Ok(this.mapper.Map<ArticleViewModel>
                (await this.articleDomain.GetByIdAsync(id)));
        }
        [HttpPost]
        public async Task<ActionResult<ArticleViewModel>> Create(ArticleViewModel articleCreateView)
        {
            try
            {
                return this.CreatedAtAction(nameof(Create),
                    await this.articleDomain.CreateAsync
                    (this.mapper.Map<ArticleCore>(articleCreateView)));
            }
            catch
            {
                return this.BadRequest();
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int articleId)
        {
            try
            {
                await this.articleDomain.DeleteAsync(articleId);
                return this.NoContent();
            }
            catch (System.Exception)
            {
                return this.BadRequest();
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ArticleUpdateViewModel))]
        [HttpPut]
        public async Task<ActionResult<ArticleUpdateViewModel>> Update(ArticleUpdateViewModel articleView)
        {
            try
            {
                var articleCore = this.mapper.Map<ArticleCore>(articleView);
                var articleCoreUpdate = await this.articleDomain.UpdateAsync(articleCore);
                return this.Ok(this.mapper.Map<ArticleUpdateViewModel>(articleCoreUpdate));
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                return this.BadRequest();
            }
        }

    }
}
