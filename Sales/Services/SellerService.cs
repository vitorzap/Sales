using System;
using Sales.Models;
using Sales.Services.Interfaces;
using Sales.Repositories.Interfaces;
namespace Sales.Services
{
    public class SellerService : GenericService<Seller>, ISellerService
    {
        public SellerService(ISellerRepository repository) : base(repository) { }

    }
}
