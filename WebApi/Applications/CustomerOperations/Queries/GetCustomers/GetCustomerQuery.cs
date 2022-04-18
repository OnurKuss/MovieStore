using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Applications.CustomerOperations.Queries.GetCustomers
{
    public class GetCustomerQuery
    {
        public CustomerViewModel Model { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetCustomerQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CustomerViewModel> Handle()
        {
            var customer = _context.Customers.Include(x => x.BoughtMovies).ThenInclude(x=> x.Movie)
                .Include(x => x.FavoriteGenres).ThenInclude(x=>x.Genre).ToList().OrderBy(x=>x.Id);

            var customerViewModel = _mapper.Map<List<CustomerViewModel>>(customer);
            return customerViewModel;
        }

    }

    public class CustomerViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> BoughtMovies { get; set; }
        public List<string> FavoriteGenres { get; set; }
    }
}
