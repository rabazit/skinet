using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public interface IProductRepository
    {
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<Product> GetProductByIdAsync(int id);
    }
}
