using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Applications.CustomerOperations.Commands.CreateCustomer;
using WebApi.Applications.CustomerOperations.Commands.DeleteCustomer;
using WebApi.Applications.CustomerOperations.Commands.UpdateCustomer;
using WebApi.Applications.CustomerOperations.Queries.GetCustomers;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CustomerController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            GetCustomerQuery query = new(_context, _mapper);
            var customers = query.Handle();
            return Ok(customers);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCustomerModel model)
        {
            CreateCustomerCommand command = new(_context, _mapper);
            command.Model = model;

            CreateCustomerCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok("Müşter bilgileri eklendi");

        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateCustomerModel model)
        {
            UpdateCustomerCommand command = new(_context);
            command.Model = model;
            command.CustomerId = id;

            UpdateCustomerCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok("Müşteri bilgileri güncellendi");

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteCustomerCommand command = new(_context);
            command.CustomerId = id;

            DeleteCustomerCommandValidator validator = new();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok("Müşteri bilgileri silindi");
        }
    }
}
