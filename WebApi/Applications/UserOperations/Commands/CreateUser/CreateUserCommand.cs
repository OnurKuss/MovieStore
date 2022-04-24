using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Applications.UserOperations.Commands.CreateUser
{
    public class CreateUserCommand
    {
        public CreateUserModel Model { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateUserCommand(IMapper mapper, IMovieStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Handler()
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == Model.Email);
            if (user!=null)
            {
                throw new InvalidOperationException("Kullanıcı zaten mevcut");
            }

            user = _mapper.Map<User>(Model);

            _context.Users.Add(user);
            _context.SaveChanges();

        }

    }

    public class CreateUserModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
