using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Data;
using RazorPizzeria.Models;

namespace RazorPizzeria.Pages.Checkout
{
    [BindProperties(SupportsGet = true)]
    public class CheckoutModel : PageModel
    {
        public string PizzaName { get; set; }
        public float PizzaPrice { get; set; }
        public string ImageTitle { get; set; }

        private readonly ApplicationDbContext _context; 
        public CheckoutModel(ApplicationDbContext context)
        {
              _context = context;   

        }

        public void OnGet()
        {
            if(string.IsNullOrWhiteSpace(PizzaName))
            {
                PizzaName = "Custom";
            }
            if(string.IsNullOrWhiteSpace(ImageTitle))
            {
                ImageTitle = "Create";
            }

            PizzaOrder2 pizzaorder2 = new PizzaOrder2();
            pizzaorder2.PizzaName = PizzaName;
            pizzaorder2.BasePrice = PizzaPrice;

            _context.PizzaOrder2s.Add(pizzaorder2);
            _context.SaveChanges();
        }
    }
}
