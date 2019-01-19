using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using H2S04.Data;
using H2S04.Models;

namespace H2S04.Pages.Secure.Cart
{
    public class CreateModel : PageModel
    {
        private readonly H2S04.Data.BaseContext _context;

        public CreateModel(H2S04.Data.BaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Bag Bag { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bag.Add(Bag);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}