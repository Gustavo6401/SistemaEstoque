using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Estoque.Domain.Entities;

namespace Estoque.Infra.Contexto
{
    public class EstoqueContext : DbContext
    {
        public DbSet<Equipamento> Equipamento { get; set; }
        public DbSet<Solicitante> Solicitante { get; set; }
        public DbSet<MaquinaSolicitada> MaquinaSolicitada { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Acesso> Acesso { get; set; }
        public DbSet<Solicitacao> Solicitacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Estoque;Trusted_Connection=True;");
        }
        public virtual void Modify(object entity) => Entry(entity).State = EntityState.Modified;

    }
}
