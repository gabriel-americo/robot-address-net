using Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        // Conjunto de endereços no contexto do banco de dados
        public DbSet<Address> Addresses { get; set; }

        // Construtor que recebe as opções de configuração do DbContext
        public AppDbContext(DbContextOptions options) : base(options) { }
    }
}
