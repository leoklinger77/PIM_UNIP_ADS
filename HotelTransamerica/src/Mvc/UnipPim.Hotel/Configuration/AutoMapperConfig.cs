using AutoMapper;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Models;

namespace UnipPim.Hotel.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CargoViewModel, Cargo>().ReverseMap();

            CreateMap<FuncionarioViewModel, Funcionario>().ReverseMap();
        }
    }
}
