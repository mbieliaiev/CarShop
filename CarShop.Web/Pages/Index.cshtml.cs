using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CarShopContext _context;

        public IndexModel(CarShopContext context)
        {
            _context = context;
        }

        public IList<CarEntity> CarEntity { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CarModels != null)
            {
                CarEntity = await _context.CarModels.ToListAsync();
            }
        }
    }
}
