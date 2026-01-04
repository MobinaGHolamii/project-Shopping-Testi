using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Data;

namespace Shop.Controllers
{
    public class SearchingProduct : Controller
    {
        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Search(string query)
        {
            List<ShopItem> results = new List<ShopItem>();

            if (!string.IsNullOrEmpty(query))
            {
                results = ItemsRepository.Items
                    .Where(x => x.Name.Contains(query, System.StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(results);
        }
    }
}
