using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace UnipPim.Hotel.Extensions.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
