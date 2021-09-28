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
               .ForMember(dest => dest.Estado, opt => opt.MapFrom(x => x.Cidade.Estado.Uf))
               .ForMember(dest => dest.Cidade, opt => opt.MapFrom(x => x.Cidade.Nome));           

            CreateMap<GrupoFuncionarioViewModel, GrupoFuncionario>().ReverseMap();
            CreateMap<AcessoViewModel, Acesso>().ReverseMap();
            CreateMap<CamaViewModel, Cama>().ReverseMap();
            CreateMap<QuartoViewModel, Quarto>().ReverseMap();

            CreateMap<AnuncioViewModel, Anuncio>().ReverseMap();
            CreateMap<FotoViewModel, Foto>().ReverseMap();


            //Paginacao
            CreateMap<PaginacaoViewModel<FuncionarioViewModel>, Paginacao<Funcionario>>().ReverseMap();
            CreateMap<PaginacaoViewModel<CargoViewModel>, Paginacao<Cargo>>().ReverseMap();
            CreateMap<PaginacaoViewModel<GrupoFuncionarioViewModel>, Paginacao<GrupoFuncionario>>().ReverseMap();
            CreateMap<PaginacaoViewModel<QuartoViewModel>, Paginacao<Quarto>>().ReverseMap();
            CreateMap<PaginacaoViewModel<AnuncioViewModel>, Paginacao<Anuncio>>().ReverseMap();

        }
    }
}
