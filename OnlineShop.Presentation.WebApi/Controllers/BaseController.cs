using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Presentation.WebApi.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
       
        public BaseController()
        {
           
        }
    }
}
