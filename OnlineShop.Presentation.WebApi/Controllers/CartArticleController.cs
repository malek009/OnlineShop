using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Business;
using OnlineShop.Core.Models;
using OnlineShop.Presentation.WebApi.ViewModels.CartsArticles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Presentation.WebApi.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class CartArticleController : ControllerBase
    {
        private readonly CartArticlesDomain cartArticlesDomain;
        private IMapper mapper;
        public CartArticleController(CartArticlesDomain cartArticlesDomain, IMapper mapper)
        {
            this.cartArticlesDomain = cartArticlesDomain;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartArticleViewModel>>> Getall()
        {
            return this.Ok(this.mapper.Map<IEnumerable<CartArticleViewModel>>
                (await this.cartArticlesDomain.GetAllAsync()));
        }
        [HttpPost]
        public async Task<ActionResult<CartArticleViewModel>> Create(CartArticleViewModel cartArticleViewModel)
        {
            try
            {
                return this.CreatedAtAction(nameof(this.Create),
                    await this.cartArticlesDomain.CreateAsync
                    (this.mapper.Map<CartArticleCore>(cartArticleViewModel)));
            }
            catch
            {
                return this.BadRequest();
            }
        }
        [HttpGet]
        public async Task<ActionResult<CartArticleViewModel>> GetById(int id)
        {
            return this.Ok(this.mapper.Map<CartArticleViewModel>(await this.cartArticlesDomain.GetByIdAsync(id)));
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int cartArticleId)
        {
            try
            {
                await this.cartArticlesDomain.DeleteAsync(cartArticleId);
                return this.NoContent();
            }
            catch (System.Exception)
            {
                return this.BadRequest();
            }
        }

    }
}
