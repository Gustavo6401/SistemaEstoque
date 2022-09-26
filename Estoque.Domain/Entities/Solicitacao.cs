using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Domain.Entities
{
    [Keyless]
    public class Solicitacao
    {
        public int IdSolicitacao { get; set; }
        public string NomeEquipamento { get; set; }
        public int QtdSolicitada { get; set; }
        public string NomeSolicitante { get; set; }
    }
}
