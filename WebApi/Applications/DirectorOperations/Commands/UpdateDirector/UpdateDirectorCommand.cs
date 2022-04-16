using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;

namespace WebApi.Applications.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        public int DirectorId { get; set; }
        public UpdateDirectorModel Model { get; set; }
        private readonly IMovieStoreDbContext _context;

        public UpdateDirectorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var director = _context.Directors.SingleOrDefault(x => x.Id == DirectorId);
            if (director == null)
            {
                throw new InvalidOperationException("Güncellenecek Yönetmen Bulunamadı.");
            }

            director.Name = Model.Name == default ? director.Name : Model.Name;
            director.Surname = Model.LastName == default ? director.Surname : Model.LastName;
            director.IsActive = Model.IsActive == default ? director.IsActive : Model.IsActive;

            _context.SaveChanges();
        }
    }

    public class UpdateDirectorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
    }
}
