using DotnetFullstack.Domain.Entities;

namespace DotnetFullstack.Domain.Interfaces
{
    public interface IProfessorRepository : IRepository<Professor>
    {
        Task<IEnumerable<Professor>> GetByNameAsync(string name);
    }
}
