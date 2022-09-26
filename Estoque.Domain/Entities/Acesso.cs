using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Domain.Entities
{
    public class Acesso
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Hora { get; set; }
        public DateTime Final { get; set; }

        public Usuario Usuario { get; set; }
    }
}
