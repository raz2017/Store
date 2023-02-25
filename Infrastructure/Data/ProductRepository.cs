using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            var productBrands = await _context.ProductsBrands.ToListAsync();
            return productBrands;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var product = await _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .FirstOrDefaultAsync(p => p.Id == productId);
            return product;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            var products = await _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .ToListAsync();
            return products;
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            var productTypes = await _context.ProductTypes.ToListAsync();
            return productTypes;
        }
    }
}