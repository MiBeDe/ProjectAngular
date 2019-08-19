using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Service;
using WebAPI.Entity;

namespace WebAPI.Domain.Services
{
  public class ClienteService : IClienteService
  {

    IClienteRepository _repository = null;

    public ClienteService(IClienteRepository repository)
    {
      _repository = repository;
    }

    public void Deletar(int Id)
    {
      _repository.Deletar(Id);
    }

    public List<ClienteEntity> ListarClientes()
    {
      return _repository.ListarClientes();
    }

    public List<ClienteEntity> ListarClientes(string nome, string cpf)
    {
      return _repository.ListarClientes(nome, cpf);
    }

    public ClienteEntity ObterClienteById(int Id)
    {
      return _repository.ObterClienteById(Id);
    }

    public void Salvar(ClienteEntity cliente)
    {
      _repository.Salvar(cliente);
    }

    public bool VerificaDuplicidadeCpf(string cpf)
    {
      return _repository.VerificaDuplicidadeCpf(cpf);
    }
  }
}
