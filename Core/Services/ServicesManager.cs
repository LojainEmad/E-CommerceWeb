using Abstraction;
using AutoMapper;
using Domain.Contracts;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServicesManager(IUnitOfWork unitOfWork ,IMapper mapper , IBasketRepository basketRepository , UserManager<ApplicationUser> userManager) : IServicesManager
    {
        private readonly Lazy<IProductServices> _LazyProductServices = new Lazy<IProductServices>(() => new ProductServices(unitOfWork , mapper));
        public IProductServices ProductServices => _LazyProductServices.Value;

        private readonly Lazy<IBasketServices> _LazyBasket = new Lazy<IBasketServices>(() => new BasketServices(basketRepository, mapper));

        public IBasketServices BasketServices => _LazyBasket.Value;


        private readonly Lazy<IAuthenticationServices> _LazyAuth = new Lazy<IAuthenticationServices>(() => new AuthenticationServices(userManager));
        public IAuthenticationServices AuthenticationServices => _LazyAuth.Value;


    }
}
