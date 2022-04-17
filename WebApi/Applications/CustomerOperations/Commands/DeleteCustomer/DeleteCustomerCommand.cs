using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Applications.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        public int CustomerId { get; set; }
        private readonly IMovieStoreDbContext _context;

        public DeleteCustomerCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var delete = _context.Customers.SingleOrDefault(x => x.Id == CustomerId);
            if (delete == null)
            {
                throw new InvalidOperationException("Silinecek Müşteri bulunamdı");
            }
            _context.Customers.Remove(delete);
            _context.SaveChanges();
        }
    }
}
