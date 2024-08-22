using ECommerce.Business.Abstract;
using ECommerce.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: ProductController
        public async Task<ActionResult> Index(int page = 1, int category = 0, bool az = true, bool highlow = false, bool w = true)
        {
            var items = await _productService.GetAllByCategoryAsync(category);
            int pageSize = 10;

            var model = new ProductListViewModel
            {
                Products = items.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageSize = pageSize,
                CurrentCategory = category,
                CurrentPage = page,
                PageCount = (int)Math.Ceiling(items.Count / (double)pageSize),
                IsAtoZ = az,
                IsHighToLow = highlow,
                Which = w
            };
            return View(model);
        }


        public async Task<ActionResult> ChangeHighLow(int page = 1, int category = 0, bool az = true, bool highlow = false)
        {
            highlow = !highlow;
            return RedirectToAction("Index", new { page, category, az, highlow, w = false });
        }

        public async Task<ActionResult> ChangeAtoZ(int page = 1, int category = 0, bool az = true, bool highlow = false)
        {
            az = !az;
            return RedirectToAction("Index", new { page, category, az, highlow, w = true });
        }


        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
