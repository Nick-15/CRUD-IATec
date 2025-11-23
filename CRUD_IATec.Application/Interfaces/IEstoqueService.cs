using CRUD_IATec.Application.DTOs;

namespace CRUD_IATec.Application.Interfaces
{
    public interface IEstoqueService
    {
        Task<IEnumerable<EstoqueDTO>> ObterTodosAsync();
        Task<EstoqueDTO?> ObterPorIdAsync(int id);
        Task<EstoqueDTO> CriarAsync(CriarEstoqueDTO dto);
        Task AtualizarAsync(int id, AtualizarEstoqueDTO dto);
        Task DeletarAsync(int id);
        Task<bool> ExisteAsync(int id);
    }
}