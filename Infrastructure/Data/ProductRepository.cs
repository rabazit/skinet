using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _storeContext;
        public ProductRepository( StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _storeContext.Products.FindAsync(id);
            return product;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            var products = await _storeContext.Products.ToListAsync();
            return products;
        }
    }
}
