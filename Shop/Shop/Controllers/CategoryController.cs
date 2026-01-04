//using Microsoft.AspNetCore.Mvc;
//using Shop.Data;

//namespace Shop.Controllers
//{
//    public class CategoryController : Controller
//    {
//        public IActionResult Category()
//        {
//            var categories = ItemsRepository.Items
//                .Where(x => !string.IsNullOrWhiteSpace(x.Category))
//                .Select(x => x.Category)
//                .Distinct()
//                .ToList();

//            return View(categories);
//        }
//        public IActionResult ProductsByCategory(string category)
//        {
//            if (string.IsNullOrEmpty(category))
//                return RedirectToAction("Category");

//            var products = ItemsRepository.Items
//                .Where(x => x.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
//                .ToList();

//            ViewBag.CategoryName = category;
//            return View(products); 
//        }
//    }
//}
