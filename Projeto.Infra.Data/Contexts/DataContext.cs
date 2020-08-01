using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Models;
using Projeto.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Contexts
{
    //REGRA 1) Herdar DbContext
    public class DataContext : DbContext
    {
        //REGRA 2) Construtor para inicializar a classe DbContext
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //REGRA 3) Declarar uma propriedade (set/get) do tipo DbSet
        //para cada entidade mapeada no sistema
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Dependente> Dependente { get; set; }
        public DbSet<Plano> Plano { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        //REGRA 4) Sobrescrita (OVERRIDE) do método OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //adicionar cada classe de mapeamento (Map)
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new DependenteMap());
            modelBuilder.ApplyConfiguration(new PlanoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            modelBuilder.Entity<Cliente>(entity => { 
                entity.HasIndex(c => c.Cpf).IsUnique();
                entity.HasIndex(c => c.Email).IsUnique();
            });

            modelBuilder.Entity<Plano>(entity => {
                entity.HasIndex(p => p.Sigla).IsUnique();
            });

            modelBuilder.Entity<Usuario>(entity => {
                entity.HasIndex(u => u.Login).IsUnique();
            });
        }
    }
}
