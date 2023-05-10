using API.Application.Repositories;

namespace API.Application.Jobs
{
    public class LogJob : ILogJob
    {
        private readonly IUnitOfWork _unitOfWork;

        public LogJob(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Log()
        {
            var productCount = _unitOfWork.ProductRepository.GetAll().Count;

            Console.WriteLine($"There are {productCount} products in the database.");
        }
    }
}
