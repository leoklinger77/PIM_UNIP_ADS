using Microsoft.AspNetCore.Mvc;
using UnipPim.Hotel.Models;

namespace UnipPim.Hotel.Extensions.ViewComponents
{
    public class PaginationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IPagedViewModel modelPagination)
        {
            return View(modelPagination);
        }
    }
}
