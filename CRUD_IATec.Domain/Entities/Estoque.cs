using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_IATec.Domain.Entities
{
    public class Estoque
    {
        public int Id { get; set; }

        [Display(Name = "Nome do produto")]
        public required string NomeProduto { get; set; }

        public int Quantidade { get; set; }

        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        // Métodos de domínio (lógica de negócio)
        public decimal CalcularValorTotal() => Quantidade * Preco;

        public bool EstaEmEstoque() => Quantidade > 0;

        public void AdicionarQuantidade(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero", nameof(quantidade));

            Quantidade += quantidade;
        }

        public void RemoverQuantidade(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero", nameof(quantidade));

            if (quantidade > Quantidade)
                throw new InvalidOperationException("Quantidade insuficiente em estoque");

            Quantidade -= quantidade;
        }

        public void AtualizarPreco(decimal novoPreco)
        {
            if (novoPreco < 0)
                throw new ArgumentException("Preço não pode ser negativo", nameof(novoPreco));

            Preco = novoPreco;
        }
    }
}