using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Application.Interface;
using WebAPI.Domain.Interfaces.Service;
using WebAPI.Entity;

namespace WebAPI.Application.Repositories
{
  public class ClienteRepositoryApp : IClienteApp
  {

    IClienteService _service = null;

    public ClienteRepositoryApp(IClienteService service)
    {
      _service = service;
    }

    public void Deletar(int Id)
    {
      _service.Deletar(Id);
    }

    public List<ClienteEntity> ListarClientes()
    {
      return _service.ListarClientes();
    }

    public List<ClienteEntity> ListarClientes(string nome, string cpf)
    {
      return _service.ListarClientes(nome, cpf);
    }

    public ClienteEntity ObterClienteById(int Id)
    {
      return _service.ObterClienteById(Id);
    }

    public void Salvar(ClienteEntity cliente)
    {
      _service.Salvar(cliente);
    }

    public bool VerificaDuplicidadeCpf(string cpf)
    {
      return _service.VerificaDuplicidadeCpf(cpf);
    }
  }
}
