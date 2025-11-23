using CRUD_IATec.Application.Interfaces;
using CRUD_IATec.Domain.Entities;
using CRUD_IATec.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUD_IATec.Infrastructure.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly EstoqueDbContext _context;

        public EstoqueRepository(EstoqueDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estoque>> GetAllAsync()
        {
            return await _context.Estoques
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Estoque?> GetByIdAsync(int id)
        {
            return await _context.Estoques
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(Estoque estoque)
        {
            await _context.Estoques.AddAsync(estoque);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Estoque estoque)
        {
            _context.Estoques.Update(estoque);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var estoque = await GetByIdAsync(id);
            if (estoque != null)
            {
                _context.Estoques.Remove(estoque);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Estoques.AnyAsync(e => e.Id == id);
        }
    }
}