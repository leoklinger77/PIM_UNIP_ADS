using AutoMapper;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Tools;
using UnipPim.Hotel.Models;

namespace UnipPim.Hotel.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CargoViewModel, Cargo>().ReverseMap();
            CreateMap<FuncionarioViewModel, Funcionario>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>()
               .ForMember(dest => dest.Estado, opt => opt.MapFrom(x => x.Cidade.Estado.Nome))
               .ForMember(dest => dest.Cidade, opt => opt.MapFrom(x => x.Cidade.Nome));

            CreateMap<PaginacaoViewModel<FuncionarioViewModel>, Paginacao<Funcionario>>().ReverseMap();
            CreateMap<PaginacaoViewModel<CargoViewModel>, Paginacao<Cargo>>().ReverseMap();
        }
    }
}
