using System.Collections.Generic;
using workshop.Models;

public interface IProductRepository
{
    IEnumerable<ProductDto> GetAll();

    ProductDto Add(ProductDto productDto);
}