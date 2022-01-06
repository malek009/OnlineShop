using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Business;
using OnlineShop.Core.Models;
using OnlineShop.Presentation.WebApi.Models;
using OnlineShop.Presentation.WebApi.ViewModels.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Presentation.WebApi.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private IMapper mapper;
        private readonly UserDomain userDomain;
        public UserController(IMapper mapper, UserDomain userDomain)
        {
            this.mapper = mapper;
            this.userDomain = userDomain;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserListViewModel>>> Getall()
        {
            return this.Ok(this.mapper.Map<IEnumerable<UserListViewModel>>( await this.userDomain.GetAllAsync()));
        }
        [HttpGet]
        public async Task<ActionResult<UserViewModel>> GetById(int id)
        {
            return this.Ok(this.mapper.Map<UserViewModel> (await this.userDomain.GetByIdAsync(id)));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserViewModel))]
        public async Task<ActionResult<UserViewModel>> Create(UserViewModel userViewModel)
        {
            try
            {
                return this.CreatedAtAction("Create",
                    await this.userDomain.CreateAsync(this.mapper.Map<UserCore>(userViewModel)));
            }
            catch
            {
                return this.BadRequest();
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            { 
                await this.userDomain.DeleteAsync(id);
                return this.NoContent();
            }
            catch (System.Exception)
            {
                return this.BadRequest();
            }
        }
        [HttpPut]
        public async Task<ActionResult<UserUpdateViewModel>> Update(UserUpdateViewModel userView)
        {
            try
            {
                var userCore = this.mapper.Map<UserCore>(userView);
                var userCoreUpdated = await this.userDomain.UpdateAsync(userCore);
                return this.Ok(this.mapper.Map<UserUpdateViewModel>(userCoreUpdated));
            }
            catch (System.Exception)
            {
                return this.BadRequest();
            }
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<UserUpdateViewModel>>> GetByParameters(UserUpdateViewModel userView)
        {
            try
            {  
                return this.Ok(await this.userDomain.GetByParametersAsync(this.mapper.Map<UserCore>(userView)));
            }
            catch (System.Exception)
            {
                return this.BadRequest();
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAllInclude()
        {
            return this.Ok(await this.userDomain.GetAllIncludeAsync());
        }
        /*[HttpPost]
        public async Task<ActionResult> PayCart()
        {
           
           var a =  await this.userDomain.payCart(cartCore);
            return this.Ok(this.mapper.Map<CartViewModel>(a));
            
        }*/

    }
}
