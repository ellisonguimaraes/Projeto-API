using Funcionarios.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Funcionarios.API.Repositories {
    public class FuncionarioRepository : IFuncionarioRepository {

        private readonly List<Funcionario> _storage;

        public FuncionarioRepository() {
            _storage = new List<Funcionario> {
                new Funcionario {
                    Id = Guid.NewGuid(),
                    Nome = "Ellison",
                    DataNascimento = new DateTime(1998, 1, 17),
                    Salario = 5892
                },
                new Funcionario {
                    Id = Guid.NewGuid(),
                    Nome = "Rebeca",
                    DataNascimento = new DateTime(1998, 5, 7),
                    Salario = 8941
                },
                new Funcionario {
                    Id = Guid.NewGuid(),
                    Nome = "Rose",
                    DataNascimento = new DateTime(1972, 9, 13),
                    Salario = 6891
                },
            };
        }

        public void Adicionar(Funcionario f) {
            _storage.Add(f);
        }

        public void Alterar(Funcionario f) {
            var index = _storage.FindIndex(0, 1, x => x.Id == f.Id);
            _storage[index] = f;
        }

        public IEnumerable<Funcionario> Listar() {
            return _storage;
        }

        public Funcionario ObterPorId(Guid id) {
            return _storage.FirstOrDefault(x => x.Id == id);
        }

        public void RemoverFuncionario(Funcionario f) {
            _storage.Remove(f);
        }
    }
}
