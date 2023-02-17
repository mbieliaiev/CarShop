using CarShop.Dto;
using CarShop.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarShop.Web.Pages
{
    public class EditModel : PageModel
    {
        private readonly ICarService _carService;

        public EditModel(ICarService carService)
        {
            _carService = carService;
        }

        [BindProperty]
        public CarDto CarModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var result =  await _carService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            CarModel = result;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _carService.Update(CarModel);

            return RedirectToPage("../Index");
        }
    }
}
