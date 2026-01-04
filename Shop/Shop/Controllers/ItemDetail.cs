using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    public class ItemDetail : Controller
    {
        public IActionResult ItemDetails(int id)
        {
            var product = ItemsRepository.Items
                .FirstOrDefault(x => x.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }
    }
}
