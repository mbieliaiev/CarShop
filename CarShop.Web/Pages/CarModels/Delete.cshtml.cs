using CarShop.Dto;
using CarShop.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarShop.Web.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ICarService _carService;

        public DeleteModel(ICarService carService)
        {
            _carService = carService;
        }

        [BindProperty]
        public CarDto CarDto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var carDto = await _carService.GetById(id);
            CarDto = carDto;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            await _carService.Delete(id);
            return RedirectToPage("../Index");
        }
    }
}
