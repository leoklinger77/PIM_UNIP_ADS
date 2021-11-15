using System.Threading.Tasks;
using UnipPim.Hotel.Desktop.Service.ModelsDTO;

namespace UnipPim.Hotel.Desktop.Service.Interfaces
{
    public interface ICaixaService
    {
        Task<ResponseResult> AbrirCaixa(decimal value);
        Task<ResponseResult> FecharCaixa();
        Task<ResponseResult<CaixaDTO>> ObterCaixa();
        Task<ResponseResult<ProdutoDTO>> BuscarProdutoPorCodigoDeBarras(string codigo);






    }
}
