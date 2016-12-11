using System;
using System.Collections.Generic;
using workshop.Models;
using System.Linq;

namespace Inventory.Models
{
    public class ProductRepository : IProductRepository
    {

        private InventoryContext _inventoryContext;

        public ProductRepository(InventoryContext InventoryContext)
        {
            this._inventoryContext = InventoryContext;
        }
        public IEnumerable<ProductDto> GetAll()
        {
            List<ProductDto> productList = SetupProducts();
            return productList;
        }

        ProductDto IProductRepository.Add(ProductDto productDto)
        {
            Product product = map(productDto);
            product.Id = Guid.NewGuid();

            this._inventoryContext.Add(product);
            this._inventoryContext.SaveChanges();

            return mapDTO(product);
        }



        private List<ProductDto> SetupProducts()
        {
            List<ProductDto> productList = new List<ProductDto>();
            ProductDto apple = CreateProduct("apple", "", 2, 5);
            ProductDto pineapple = CreateProduct("Pineapple", "", 2, 5);

            productList.Add(apple);
            productList.Add(pineapple);
            return productList;
        }

        private ProductDto CreateProduct(string name, string image, double costPrice, double sellingPrice)
        {
            ProductDto product = new ProductDto();
            product.Name = name;
            product.Image = image;
            product.CostPrice = costPrice;
            product.SellingPrice = sellingPrice;

            return product;
        }

        private ProductDto mapDTO(Product product)
        {
            ProductDto productResultDTO = new ProductDto();
            productResultDTO.Id = product.Id;
            productResultDTO.Name = product.Name;
            productResultDTO.Image = product.Image;
            productResultDTO.SellingPrice = product.sellingPrice;
            productResultDTO.CostPrice = product.costPrice;

            return productResultDTO;
        }
        private Product map(ProductDto productDto)
        {
            Product product = new Product();
            product.Name = productDto.Name;
            product.sellingPrice = productDto.SellingPrice;
            product.costPrice = productDto.CostPrice;
            product.Image = productDto.Image;

            return product;
        }


    }
}