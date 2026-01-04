using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactUs : Controller
    {
        [HttpGet]
        public IActionResult ContactUS()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ContactUS(ContactMessage message)
        {
            if (ModelState.IsValid)
            {
                ContactRepository.AddMessage(message);
                TempData["SuccessMessage"] = "پیامت ارسال شد ";
                return RedirectToAction("SendMessage");
            }

            return View(message);
        }
    }
}
