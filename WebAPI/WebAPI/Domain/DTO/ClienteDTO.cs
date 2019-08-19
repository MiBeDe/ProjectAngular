using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Domain.DTO
{
  public class ClienteDTO
  {
    public int IdCliente { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string RG { get; set; }
    public string CPF { get; set; }

  }
}
