using AccesoDatos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AccesoDatos.Contexto
{
    public class ContextoBD : DbContext
    {
        public ContextoBD()
        {
        }

        public ContextoBD(DbContextOptions<ContextoBD> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {                
                var connectionString = "Initial Catalog=pichinchabd; Data Source=localhost,1450;Database=pichincha; Persist Security Info=True;User ID=SA;Password= 2Secure*Password2;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
    }
}