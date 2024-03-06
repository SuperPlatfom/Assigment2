using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SignalRAssignment.Data;
using SignalRAssignment.Models;

namespace SignalRAssignment.Pages.OrderPage
{
    public class CreateModel : PageModel
    {
        public List<Customer> listCus;
        private readonly SignalRAssignment.Data.PRN221_As02Context _context;

        public CreateModel(SignalRAssignment.Data.PRN221_As02Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            listCus = _context.Customers.ToList();
            return Page();
        }

        [BindProperty]
        public Order Orders { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync() 
        {
            //if (!ModelState.IsValid)
            //  {
            //      return Page();
            //  }
            listCus = _context.Customers.ToList();
            var cus = listCus.FirstOrDefault(x => x.CustomerId == Orders.CustomerId);
            Orders.Customer = cus;
            _context.Orders.Add(Orders);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
