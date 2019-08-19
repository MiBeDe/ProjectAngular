using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entity;

namespace WebAPI.Domain.Interfaces.Repository
{
  public interface IClienteRepository
  {
    List<ClienteEntity> ListarClientes();
    List<ClienteEntity> ListarClientes(string nome, string cpf);
    ClienteEntity ObterClienteById(int Id);
    bool VerificaDuplicidadeCpf(string cpf);
    void Salvar(ClienteEntity cliente);
    void Deletar(int Id);
  }
}
