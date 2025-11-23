using CRUD_IATec.Application.DTOs;
using CRUD_IATec.Application.Interfaces;
using CRUD_IATec.Domain.Entities;

namespace CRUD_IATec.Application.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IEstoqueRepository _repository;

        public EstoqueService(IEstoqueRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EstoqueDTO>> ObterTodosAsync()
        {
            var estoques = await _repository.GetAllAsync();

            return estoques.Select(e => new EstoqueDTO
            {
                Id = e.Id,
                NomeProduto = e.NomeProduto,
                Quantidade = e.Quantidade,
                Preco = e.Preco,
                ValorTotal = e.CalcularValorTotal(),
                EmEstoque = e.EstaEmEstoque()
            });
        }

        public async Task<EstoqueDTO?> ObterPorIdAsync(int id)
        {
            var estoque = await _repository.GetByIdAsync(id);

            if (estoque == null)
                return null;

            return new EstoqueDTO
            {
                Id = estoque.Id,
                NomeProduto = estoque.NomeProduto,
                Quantidade = estoque.Quantidade,
                Preco = estoque.Preco,
                ValorTotal = estoque.CalcularValorTotal(),
                EmEstoque = estoque.EstaEmEstoque()
            };
        }

        public async Task<EstoqueDTO> CriarAsync(CriarEstoqueDTO dto)
        {
            var estoque = new Estoque
            {
                NomeProduto = dto.NomeProduto,
                Quantidade = dto.Quantidade,
                Preco = dto.Preco
            };

            await _repository.AddAsync(estoque);

            return new EstoqueDTO
            {
                Id = estoque.Id,
                NomeProduto = estoque.NomeProduto,
                Quantidade = estoque.Quantidade,
                Preco = estoque.Preco,
                ValorTotal = estoque.CalcularValorTotal(),
                EmEstoque = estoque.EstaEmEstoque()
            };
        }

        public async Task AtualizarAsync(int id, AtualizarEstoqueDTO dto)
        {
            var estoque = await _repository.GetByIdAsync(id);

            if (estoque == null)
                throw new KeyNotFoundException($"Estoque com ID {id} não encontrado");

            estoque.NomeProduto = dto.NomeProduto;
            estoque.Quantidade = dto.Quantidade;
            estoque.AtualizarPreco(dto.Preco);

            await _repository.UpdateAsync(estoque);
        }

        public async Task DeletarAsync(int id)
        {
            var estoque = await _repository.GetByIdAsync(id);

            if (estoque == null)
                throw new KeyNotFoundException($"Estoque com ID {id} não encontrado");

            await _repository.DeleteAsync(id);
        }

        public async Task<bool> ExisteAsync(int id)
        {
            return await _repository.ExistsAsync(id);
        }
    }
}