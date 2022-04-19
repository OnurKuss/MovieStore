using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Applications.OrderOperations.Commands
{
    public class CreateOrderCommand
    {
        public CreateOrderModel Model { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateOrderCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool Handle()
        {
            var order = _mapper.Map<Order>(Model);
            order.OrderDate = DateTime.Now;
            _context.Orders.Add(order);
            int result= _context.SaveChanges();
            return Convert.ToBoolean(result);
        }
    }

    public class CreateOrderModel
    {
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public decimal Price { get; set; }
    }
}
