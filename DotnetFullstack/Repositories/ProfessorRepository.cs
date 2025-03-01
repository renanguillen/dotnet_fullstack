using DotnetFullstack.Data;
using DotnetFullstack.Domain.Entities;
using DotnetFullstack.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DotnetFullstack.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly AppDbContext _context;

        public ProfessorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Professor>> GetAllAsync()
        {
            return await _context.Professors.AsNoTracking().ToListAsync();
        }

        public async Task<Professor?> GetByIdAsync(Guid id)
        {
            return await _context.Professors.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Professor professor)
        {
            _context.Professors.Add(professor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Professor professor)
        {
            var existingProfessor = await _context.Professors.FindAsync(professor.Id);

            if (existingProfessor != null)
            {
                _context.Entry(existingProfessor).State = EntityState.Detached;
            }

            _context.Professors.Attach(professor);
            _context.Entry(professor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var professor = await _context.Professors.FindAsync(id);
            if (professor != null)
            {
                _context.Professors.Remove(professor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Professor>> GetByNameAsync(string name)
        {
            return await _context.Professors
                .AsNoTracking()
                .Where(p => p.Name.Contains(name))
                .ToListAsync();
        }
    }
}
