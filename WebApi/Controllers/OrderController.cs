using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.OrderOperations.Commands;
using WebApi.Applications.OrderOperations.Queries;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public OrderController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderDetail(int id)
        {
            GetOrderDetailQuery query = new(_context, _mapper);
            query.OrderId = id;
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateOrderMovie([FromBody] CreateOrderModel model)
        {
            CreateOrderCommand command = new(_context, _mapper);
            command.Model = model;
            var result = command.Handle();
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}
