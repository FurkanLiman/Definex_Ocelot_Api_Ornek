using Microsoft.EntityFrameworkCore;
using Writer.Api.Data;
using Writer.Api.Models;
using Writer.Api.Repositories.Interfaces;

namespace Writer.Api.Repositories
{
    public class WriterRepository : IWriterRepository
    {
        private readonly WriterDbContext _context;

        public WriterRepository(WriterDbContext context)
        {
            _context = context;
        }

        public List<Models.Writer> getAll()
        {
            return _context.Writers.Where(w => w.IsActive == 1).ToList();
        }

        public Models.Writer? Get(int id)
        {
            return _context.Writers.FirstOrDefault(w => w.Id == id && w.IsActive == 1);
        }

        public Models.Writer Insert(Models.Writer writer)
        {
            _context.Writers.Add(writer);
            _context.SaveChanges();
            return writer;
        }

        public Models.Writer Update(Models.Writer writer)
        {
            _context.Entry(writer).State = EntityState.Modified;
            _context.SaveChanges();
            return writer;
        }

        public int Delete(int id)
        {
            var writer = _context.Writers.FirstOrDefault(w => w.Id == id);
            if (writer == null)
            {
                return 0;
            }
            
            // Soft delete
            writer.IsActive = 0;
            _context.SaveChanges();
            return 1;
        }
    }
}
