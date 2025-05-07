using Abstraction;
using Microsoft.AspNetCore.Mvc;
using Shared.Dto_s.BasketBto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BasketController(IServicesManager servicesManager):ControllerBase
    {
        //Get Basket
        [HttpGet]    //Get BaseURl/api/Basket
        public async Task<ActionResult<BasketDto>> GetBasket(string key)
        {
            var Basket =await servicesManager.BasketServices.GetBasketAsync(key);
            return Ok(Basket);
        }



        //CreteOrUpdateBasket

        [HttpPost]
        public async Task<ActionResult<BasketDto>> CreateOrUpdateBasket(BasketDto basket)
        {
            var Basket = await servicesManager.BasketServices.CreateOrUpdateBasketAsync(basket);
            return Ok(Basket);
        }


        //Delete Basket
        [HttpDelete("{key}")]
        public async Task<ActionResult<bool>> DeleteBasket(string key)
        {
            var Result = await servicesManager.BasketServices.DeleteBasketAsync(key);
            return Ok(Result);
        }


    }
}
