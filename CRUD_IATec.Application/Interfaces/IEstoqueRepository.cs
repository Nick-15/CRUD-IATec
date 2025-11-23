using CRUD_IATec.Domain.Entities;

namespace CRUD_IATec.Application.Interfaces
{
    public interface IEstoqueRepository
    {
        Task<IEnumerable<Estoque>> GetAllAsync();
        Task<Estoque?> GetByIdAsync(int id);
        Task AddAsync(Estoque estoque);
        Task UpdateAsync(Estoque estoque);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}