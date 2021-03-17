using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackAngular.Models
{
    public class UsuarioOutputModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Parcelas { get; set; }
        public double Valor { get; set; }        
    }
}
