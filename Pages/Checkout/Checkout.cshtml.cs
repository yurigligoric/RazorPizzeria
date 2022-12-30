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

        private readonly ApplicationDBContext _context;
        public CheckoutModel(ApplicationDBContext context)
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

            PizzaOrder pizzaorder = new PizzaOrder();
            pizzaorder.PizzaName = PizzaName;
            pizzaorder.BasePrice = PizzaPrice;  

            _context.PizzaOrders.Add(pizzaorder);
            _context.SaveChanges();

        }
    }
}
