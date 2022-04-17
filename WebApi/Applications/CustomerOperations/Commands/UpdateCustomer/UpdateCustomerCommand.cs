using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Applications.CustomerOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand
    {
        public int CustomerId { get; set; }
        public UpdateCustomerModel Model { get; set; }
        private readonly IMovieStoreDbContext _context;

        public UpdateCustomerCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == CustomerId);
            if (customer == null)
            {
                throw new InvalidOperationException("Güncellenecek müşteri Bulunamadı.");
            }

            customer.Name = Model.Name == default ? customer.Name : Model.Name;
            customer.Surname = Model.LastName == default ? customer.Surname : Model.LastName;

            _context.SaveChanges();
        }

    }
    public class UpdateCustomerModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
