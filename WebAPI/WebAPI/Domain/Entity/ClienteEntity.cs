using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entity
{
  [Table("TbClientes", Schema = "dbo")]
  public class ClienteEntity
  {
      [Key]
      public int IdCliente { get; set; }
      public string Nome { get; set; }
      public string Sobrenome { get; set; }
      public string RG { get; set; }
      public string CPF { get; set; }

  }
}
