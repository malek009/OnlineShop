using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Business;
using OnlineShop.Core.Models;
using OnlineShop.Presentation.WebApi.ViewModels.Carts;
using OnlineShop.Presentation.WebApi.ViewModels.CartsArticles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Presentation.WebApi.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
       
        private IMapper mapper;
        private readonly CartDomain cartDomain;
        public CartController(IMapper mapper,CartDomain cartDomain)
        {
            this.mapper = mapper;
            this.cartDomain = cartDomain;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartListViewModel>>> GetAll()
        {
                return this.Ok(this.mapper.Map<IEnumerable<CartListViewModel>>
                    (await this.cartDomain.GetAllAsync()));
        }
        [HttpGet]
        public async Task<ActionResult<CartViewModel>> GetById(int id)
        {
            return this.Ok(this.mapper.Map<CartViewModel>(await this.cartDomain.GetByIdAscy(id)));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CartViewModel))]
        public async Task<ActionResult<CartViewModel>> Create(CartViewModel cartViewModel)
        {
            try
            {
                return this.CreatedAtAction(nameof(this.Create),
                    await this.cartDomain.CreateAsync(this.mapper.Map<CartCore>(cartViewModel)));
            }
            catch
            {
                return this.BadRequest();
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int cartId)
        {
            try
            {
                await this.cartDomain.DeleteAsync(cartId);
                return this.NoContent();
            }
            catch (System.Exception)
            {
                return this.BadRequest();
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartListViewModel>>> GetAllInclude()
        {
            return this.Ok(await this.cartDomain.GetAllIncludeAsync());
        }

        [HttpPost]
        public async Task<ActionResult<CartViewModel>> AddArticleToCart(CartArticleViewModel cartArticleVieuwModel)
        {
            var cartArticleCore = this.mapper.Map<CartArticleCore>(cartArticleVieuwModel);

            var cartCore = await this.cartDomain.AddArticleToCartAsync(cartArticleCore);
            return this.Ok(this.mapper.Map<CartViewModel>(cartCore));
        }


    }
}
