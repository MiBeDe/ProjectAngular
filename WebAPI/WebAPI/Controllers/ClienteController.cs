using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.Interface;
using WebAPI.Data.Context;
using WebAPI.Domain.DTO;
using WebAPI.Entity;

namespace WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ClienteController : ControllerBase
  {
    private readonly IMapper _mapper;
    IClienteApp _clienteApp;

    public ClienteController(IMapper mapper, IClienteApp clienteApp)
    {
      _mapper = mapper;
      _clienteApp = clienteApp;
    }

    //LISTAR TODOS OS CLIENTES
    [AcceptVerbs("GET")]
    [Route("ListarClientes")]
    public ObjectResult Get()
    {
      var clienteEntity = _clienteApp.ListarClientes();
      var clienteDTO = _mapper.Map<List<ClienteDTO>>(clienteEntity);
      return StatusCode((int)HttpStatusCode.OK, clienteDTO);

    }
    //GET CLIENTES BY ID
    [AcceptVerbs("GET")]
    [Route("ObterCliente/{id}")]
    public ObjectResult Get(int id)
    {
      var clienteEntity = _clienteApp.ObterClienteById(id);
      var clienteDTO = _mapper.Map<ClienteDTO>(clienteEntity);
      return StatusCode((int)HttpStatusCode.OK, clienteDTO);

    }

    //INSERIR CLIENTE
    // POST: api/Cliente
    [AcceptVerbs("POST")]
    [Route("InserirCliente")]
    public ObjectResult Post([FromBody] ClienteDTO cliente)
    {
      var clienteEntity = _mapper.Map<ClienteEntity>(cliente);
      _clienteApp.Salvar(clienteEntity);
      return StatusCode((int)HttpStatusCode.Created, cliente);
    }

    //ALTERAR CLIENTE
    [AcceptVerbs("PUT")]
    [Route("AlterarCliente")]
    public ObjectResult Put([FromBody] ClienteDTO cliente)
        {
      var clienteEntity = _mapper.Map<ClienteEntity>(cliente);
      _clienteApp.Salvar(clienteEntity);
      return StatusCode((int)HttpStatusCode.Created, cliente);
    }

    // DELETAR CLIENTE
    [AcceptVerbs("DELETE")]
    [Route("DeleteCliente/{id}")]
    public ObjectResult Delete(int id)
    {
      _clienteApp.Deletar(id);
      return StatusCode((int)HttpStatusCode.Created, id);
    }
  }
}
