using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces.Repositories;
using Estoque.Infra.Contexto;
using Estoque.Infra.Repositories.Base;

namespace Estoque.Infra.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        EstoqueContext Db = new();
        public Usuario Login(string nome, string senha) => Db.Usuario.FirstOrDefault(t => t.Nome.Equals(nome)
                                                                                     && t.Senha.Equals(senha));

        public IEnumerable<Usuario> ProcurarUsuario(string nome) => Db.Usuario.Where(t => t.Nome.Contains(nome));
    }
}
