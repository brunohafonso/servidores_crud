using cadastrodeservidores.Models;
using Microsoft.EntityFrameworkCore;

namespace cadastrodeservidores.Dados
{
    public class PmspContext : DbContext
    {
        public PmspContext(DbContextOptions options ) : base(options) { }
        
        public DbSet<Servidor> Servidores { get; set; }
        
        public DbSet<Endereco> Enderecos { get; set; }
        
    }
}