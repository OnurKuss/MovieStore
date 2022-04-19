using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Applications.OrderOperations.Queries
{
    public class GetOrderDetailQuery
    {
        public int OrderId { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetOrderDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public OrderDetailViewModel Handle()
        {
            var order= _context.Orders.Include(x=> x.Customer).Include(X=>X.Movie)
                .SingleOrDefault(x => x.Id == OrderId && x.IsVisible == true);
            if (order== null)
                throw new InvalidOperationException("Satın alma bulunamadı!");

            var result = _mapper.Map<OrderDetailViewModel>(order);

            return result;
        }
    }

    public class OrderDetailViewModel
    {
        public string Customer { get; set; }
        public string Movie { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
    }
}
