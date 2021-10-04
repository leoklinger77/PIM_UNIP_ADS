using System.Threading.Tasks;
using UnipPim.Hotel.Desktop.Service.ModelsDTO;

namespace UnipPim.Hotel.Desktop.Service.Interfaces
{
    public interface ILoginService
    {
        Task<ResponseResult> Login(LoginRequest login);
    }
}
