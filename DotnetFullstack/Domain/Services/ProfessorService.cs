using DotnetFullstack.Domain.Entities;
using DotnetFullstack.Domain.Interfaces;

namespace DotnetFullstack.Domain.Services
{
    public class ProfessorService
    {
        private readonly IProfessorRepository _repository;

        public ProfessorService(IProfessorRepository repository) => _repository = repository;

        public async Task<IEnumerable<Professor>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Professor?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(string name, string biography)
        {
            var professor = new Professor(name, biography);
            await _repository.AddAsync(professor);
        }

        public async Task UpdateAsync(Guid id, string name, string biography)
        {
            var professor = await _repository.GetByIdAsync(id) ?? throw new Exception("Professor not found.");
            professor.Update(name, biography);
            await _repository.UpdateAsync(professor);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
