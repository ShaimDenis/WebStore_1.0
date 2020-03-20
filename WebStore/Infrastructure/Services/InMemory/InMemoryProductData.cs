using System.Collections.Generic;
using System.Linq;
using WebStore.Data;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Services
{
    public class InMemoryProductData : IProductData
    {
        public IEnumerable<Section> GetSections() => DataSections.Sections;

        public IEnumerable<Brand> GetBrands() => DataBrands.Brands;

        public IEnumerable<Product> GetProducts(ProductFilter Filter = null)
        {
            var query = DataProducts.Products;

            if (Filter?.SectionId != null)
                query = query.Where(product => product.SectionId == Filter.SectionId);

            if (Filter?.BrandId != null)
                query = query.Where(product => product.BrandId == Filter.BrandId);

            return query;
        }
    }
}
