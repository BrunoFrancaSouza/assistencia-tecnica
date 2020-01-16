using AssistenciaTecnica.Domain;
using AssistenciaTecnica.WebAPI.DTOs;
using AutoMapper;

namespace AssistenciaTecnica.WebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Empresa, EmpresaDTO>().ReverseMap();
        }
    }
}