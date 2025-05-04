using Domain.Models;
using Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IUnitOfWork
    {
        //IGenericRepository<Product,int>ProductRepo { get; }
        Task<int> SaveChangesAsync();

        IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>()
            where TEntity : ModelBase<Tkey>;
    }
}
