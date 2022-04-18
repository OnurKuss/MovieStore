using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Applications.ActorOperations.Commands.CreateActor;
using WebApi.Applications.ActorOperations.Commands.DeleteActor;
using WebApi.Applications.ActorOperations.Commands.UpdateActor;
using WebApi.Applications.ActorOperations.Queries.GetActorDetail;
using WebApi.Applications.ActorOperations.Queries.GetActors;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public ActorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetActors()
        {
            GetActorsQuery query = new(_context, _mapper);
            return Ok(query.Handle());
        }

        [HttpGet("{id}")]
        public IActionResult GetActorDetails(int id)
        {
            GetActorDetailQuery query = new(_context, _mapper);
            query.ActorId = id;
            GetActorDetailQueryValidator validator = new();
            validator.ValidateAndThrow(query);
            return Ok(query.Handle());
        }

        [HttpPost]
        public IActionResult AddActor([FromBody] CreateActorModel model)
        {
            CreateActorCommand command = new(_context,_mapper);
            command.Model = model;
            CreateActorCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok("Aktör başarı ile eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
            DeleteActorCommand command = new(_context);
            command.ActorId = id;
            DeleteActorCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok("Aktör başarı ile silindi!!");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActor(int id, [FromBody] UpdateActorModel model)
        {
            UpdateActorCommand command = new(_context);
            command.ActorId = id;
            command.Model = model;
            UpdateActorCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok("Aktör başarı ile güncellendi!!");
        }
    }
}
