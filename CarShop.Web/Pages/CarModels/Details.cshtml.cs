using CarShop.Dto;
using CarShop.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarShop.Web.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ICarService _carService;

        public DetailsModel(ICarService carService)
        {
            _carService = carService;
        }

        public CarDto CarEntity { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var carentity = await _carService.GetById(id);
            CarEntity = carentity;
            return Page();
        }
    }
}
