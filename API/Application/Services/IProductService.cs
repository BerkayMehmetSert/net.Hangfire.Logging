using API.Application.Requests;
using API.Application.Responses;

namespace API.Application.Services
{
    public interface IProductService
    {
        void CreateProduct(CreateProductRequest request);
        void UpdateProduct(Guid id ,UpdateProductRequest request);
        void DeleteProduct(Guid id);
        ProductResponse GetProductById(Guid id);
        ProductResponse GetProductByName(string name);
        List<ProductResponse> GetAllProducts();
        List<ProductResponse> GetProductsByPriceDescending();
        List<ProductResponse> GetProductsByPriceAscending();
    }
}
