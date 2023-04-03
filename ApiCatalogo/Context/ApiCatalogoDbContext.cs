using ApiCatalogo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApiCatalogo.Context
{
    public class ApiCatalogoDbContext : DbContext
    {
        public ApiCatalogoDbContext(DbContextOptions<ApiCatalogoDbContext> options) : base(options)
        {
        }
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Produto>? Produtos { get; set; }
    }
}
