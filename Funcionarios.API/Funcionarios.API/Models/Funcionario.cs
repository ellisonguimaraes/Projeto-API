using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Funcionarios.API.Models {
    public class Funcionario {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public decimal Salario { get; set; }
    }
}
