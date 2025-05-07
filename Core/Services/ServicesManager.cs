using Abstraction;
using AutoMapper;
using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServicesManager(IUnitOfWork unitOfWork ,IMapper mapper , IBasketRepository basketRepository) : IServicesManager
    {
        private readonly Lazy<IProductServices> _LazyProductServices = new Lazy<IProductServices>(() => new ProductServices(unitOfWork , mapper));
        public IProductServices ProductServices => _LazyProductServices.Value;

        private readonly Lazy<IBasketServices> _LazyBasket = new Lazy<IBasketServices>(() => new BasketServices(basketRepository, mapper));

        public IBasketServices BasketServices => _LazyBasket.Value;
    }
}
