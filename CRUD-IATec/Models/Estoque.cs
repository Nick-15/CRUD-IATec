using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_IATec.Models
{
    public class Estoque
    {
        public int Id { get; set; }

        public required string NomeProduto { get; set; }

        public int Quantidade { get; set; }

        public decimal Preco { get; set; }
    }
}