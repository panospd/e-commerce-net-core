using System.Linq;
using System.Threading.Tasks;
using AspnetRunBasics.ApiCollection.Interfaces;
using AspnetRunBasics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics
{
    public class CartModel : PageModel
    {
        private readonly IBasketApi _basketApi;

        public CartModel(IBasketApi basketApi)
        {
            _basketApi = basketApi;
        }


        public BasketModel Cart { get; set; } = new BasketModel();        

        public async Task<IActionResult> OnGetAsync()
        {
            var username = "swn";

            Cart = await _basketApi.GetBasket(username);            

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(string productId)
        {
            var username = "swn";

            var basket = await _basketApi.GetBasket(username);

            var item = basket.Items.Single(i => i.ProductId == productId);
            basket.Items.Remove(item);

            await _basketApi.UpdateBasket(basket);

            return RedirectToPage();
        }
    }
}