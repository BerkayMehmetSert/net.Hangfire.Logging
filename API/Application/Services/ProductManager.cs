using API.Application.Repositories;
using API.Application.Requests;
using API.Application.Responses;
using API.Domain.Entities;
using AutoMapper;

namespace API.Application.Services
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateProduct(CreateProductRequest request)
        {
            CheckIfProductExistsByName(request.Name);

            var product = _mapper.Map<Product>(request);

            _unitOfWork.ProductRepository.Create(product);
            _unitOfWork.SaveChanges();
        }

        public void UpdateProduct(Guid id, UpdateProductRequest request)
        {
            var product = GetProduct(id);

            if (product.Name != request.Name)
            {
                CheckIfProductExistsByName(request.Name);
            }

            var updatedProduct = _mapper.Map(request, product);

            _unitOfWork.ProductRepository.Update(updatedProduct);
            _unitOfWork.SaveChanges();
        }

        public void DeleteProduct(Guid id)
        {
            var product = GetProduct(id);
            _unitOfWork.ProductRepository.Delete(product);
            _unitOfWork.SaveChanges();
        }

        public ProductResponse GetProductById(Guid id)
        {
            var product = GetProduct(id);
            return _mapper.Map<ProductResponse>(product);
        }

        public ProductResponse GetProductByName(string name)
        {
            var product = _unitOfWork.ProductRepository.Get(x => x.Name == name);

            if (product is null)
            {
                throw new Exception("Product not found");
            }

            return _mapper.Map<ProductResponse>(product);
        }

        public List<ProductResponse> GetAllProducts()
        {
            var products = _unitOfWork.ProductRepository.GetAll();

            if (products.Count == 0)
            {
                throw new Exception("Product list is empty");
            }

            return _mapper.Map<List<ProductResponse>>(products);
        }

        public List<ProductResponse> GetProductsByPriceDescending()
        {
            var products = _unitOfWork.ProductRepository.GetAll(
                orderBy: x => x.OrderByDescending(x => x.Price));

            if (products.Count == 0)
            {
                throw new Exception("Product list is empty");
            }

            return _mapper.Map<List<ProductResponse>>(products);
        }

        public List<ProductResponse> GetProductsByPriceAscending()
        {
            var products = _unitOfWork.ProductRepository.GetAll(
                orderBy: x => x.OrderBy(x => x.Price));

            if (products.Count == 0)
            {
                throw new Exception("Product list is empty");
            }

            return _mapper.Map<List<ProductResponse>>(products);
        }

        private Product GetProduct(Guid id)
        {
            var product = _unitOfWork.ProductRepository.Get(x => x.Id == id);

            return product ?? throw new Exception("Product not found");
        }

        private void CheckIfProductExistsByName(string name)
        {
            var product = _unitOfWork.ProductRepository.Get(x => x.Name == name);

            if (product is not null)
            {
                throw new Exception("Product with this name already exists");
            }
        }
    }
}
