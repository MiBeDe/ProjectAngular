using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPI.Data.Repositories.Base;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Entity;

namespace WebAPI.Data.Repositories
{
  public class ClienteRepository : IClienteRepository
  {
    public void Deletar(int Id)
    {
      Expression<Func<ClienteEntity, bool>> expressionFiltro = (a => a.IdCliente != 0 && a.IdCliente == (Int64)Id);

      using (var rep = new RepositoryBase<ClienteEntity>())
      {
        ClienteEntity cliente = rep.Select(expressionFiltro).FirstOrDefault();
        if(cliente != null)
        {
          rep.Delete(cliente);
        }
      }
    }

    public List<ClienteEntity> ListarClientes()
    {
      List<ClienteEntity> ListaClientes = new List<ClienteEntity>();
      //string[] includes = new string[] { "Unidades" };
      Expression<Func<ClienteEntity, bool>> expressionFiltro = (a => a.IdCliente != 0);

      using (var rep = new RepositoryBase<ClienteEntity>())
      {
        ListaClientes = rep.Select(expressionFiltro).ToList();
      }

      return ListaClientes;
    }

    public List<ClienteEntity> ListarClientes(string nome, string cpf)
    {
      List<ClienteEntity> ListaClientes = new List<ClienteEntity>();
      //string[] includes = new string[] { "Unidades" };
      Expression<Func<ClienteEntity, bool>> expressionFiltro = (a => a.IdCliente != 0);

      using (var rep = new RepositoryBase<ClienteEntity>())
      {
        ListaClientes = rep.Select(expressionFiltro).ToList();
      }

      return ListaClientes;
    }

    public ClienteEntity ObterClienteById(int Id)
    {
      ClienteEntity cliente = new ClienteEntity();
      //string[] includes = new string[] { "Unidades" };
      Expression<Func<ClienteEntity, bool>> expressionFiltro = (a => a.IdCliente != 0 && a.IdCliente == (Int64)Id);

      using (var rep = new RepositoryBase<ClienteEntity>())
      {
        cliente = rep.Select(expressionFiltro).FirstOrDefault();
      }

      return cliente;
    }

    public void Salvar(ClienteEntity cliente)
    {
      using (var rep = new RepositoryBase<ClienteEntity>())
      {
        if (cliente.IdCliente == 0)
        {
          rep.Insert(cliente);
        }
        else
        {
          rep.Update(cliente);
        }
      }
    }

    public bool VerificaDuplicidadeCpf(string cpf)
    {
      bool retorno = false;

      Expression<Func<ClienteEntity, bool>> expressionFiltro = (a => a.IdCliente != 0 && a.CPF.Trim() == cpf.Trim());

      using (var rep = new RepositoryBase<ClienteEntity>())
      {
        var cliente = rep.Select(expressionFiltro).FirstOrDefault();
        if( cliente != null)
        {
          retorno = true;
        }
      }
      return retorno;
    }
  }
}
