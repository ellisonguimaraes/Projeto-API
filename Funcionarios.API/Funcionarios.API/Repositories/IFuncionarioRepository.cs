using Funcionarios.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Funcionarios.API.Repositories {
    public interface IFuncionarioRepository {
        void Adicionar(Funcionario f);
        void Alterar(Funcionario f);
        IEnumerable<Funcionario> Listar();
        Funcionario ObterPorId(Guid id);
        void RemoverFuncionario(Funcionario f);
    }
}
