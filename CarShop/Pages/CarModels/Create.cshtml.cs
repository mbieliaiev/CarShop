using CarShop.Dto;
using CarShop.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarShop.Web.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ICarService _carService;

        public CreateModel(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CarDto CarModel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _carService.Insert(CarModel);

            return RedirectToPage("../Index");
        }
    }
}
