using System.ComponentModel.DataAnnotations;

namespace CRUD_IATec.Application.DTOs
{
    public class EstoqueDTO
    {
        public int Id { get; set; }

        [Display(Name = "Nome do produto")]
        public string NomeProduto { get; set; } = string.Empty;

        public int Quantidade { get; set; }

        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        [Display(Name = "Valor Total")]
        [DataType(DataType.Currency)]
        public decimal ValorTotal { get; set; }

        [Display(Name = "Em Estoque")]
        public bool EmEstoque { get; set; }
    }

    public class CriarEstoqueDTO
    {
        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        [Display(Name = "Nome do produto")]
        [StringLength(200, ErrorMessage = "O nome não pode exceder 200 caracteres")]
        public string NomeProduto { get; set; } = string.Empty;

        [Required(ErrorMessage = "A quantidade é obrigatória")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade deve ser maior ou igual a zero")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        [Display(Name = "Preço")]
        [Range(0, double.MaxValue, ErrorMessage = "O preço deve ser maior ou igual a zero")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }
    }

    public class AtualizarEstoqueDTO
    {
        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        [Display(Name = "Nome do produto")]
        [StringLength(200, ErrorMessage = "O nome não pode exceder 200 caracteres")]
        public string NomeProduto { get; set; } = string.Empty;

        [Required(ErrorMessage = "A quantidade é obrigatória")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade deve ser maior ou igual a zero")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        [Display(Name = "Preço")]
        [Range(0, double.MaxValue, ErrorMessage = "O preço deve ser maior ou igual a zero")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }
    }
}