using Shared.Dto_s.BasketBto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public interface IBasketServices
    {
        Task<BasketDto> GetBasketAsync(string key);

        Task<BasketDto> CreateOrUpdateBasketAsync(BasketDto basket);

        Task<bool> DeleteBasketAsync(string key);

    }
}
