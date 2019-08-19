using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Domain.DTO;
using WebAPI.Entity;

namespace WebAPI.Mappings
{
  public class MappingProfiles : Profile
  {
    public MappingProfiles()
    {
      CreateMap<ClienteEntity, ClienteDTO>().ReverseMap();
    }
  }
}
