using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CRUD_IATec.Models
{
    public class EstoqueDbContext : DbContext
    {
        public EstoqueDbContext(DbContextOptions<EstoqueDbContext> options) : base(options)
        {

        }
        
        public DbSet<Estoque> Estoques { get; set; }
    }
}