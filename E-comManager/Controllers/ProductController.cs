using E_comManager.Data;
using E_comManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_comManager.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var products = _repository.GetAllProducts();    
            return View(products);
        }
        public IActionResult ViewProduct(int id)
        {
            var product = _repository.GetProduct(id);
            return View(product);
        }
        public IActionResult UpdateProduct(int id)
        {
            Product prod = _repository.GetProduct(id);
            if (prod == null)
            {
                return View("ProductNotFound");
            }
            return View(prod);
        }
        public IActionResult UpdateProductToDatabase(Product product)
        {
            _repository.UpdateProduct(product);

            return RedirectToAction("ViewProduct", new { id = product.ProductID });
        }
        public IActionResult InsertProduct()
        {
            var prod = _repository.AssignCategory();
            return View(prod);
        }
        public IActionResult InsertProductToDatabase(Product productToInsert)
        {
            _repository.InsertProduct(productToInsert);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(Product product)
        {
            _repository.DeleteProduct(product);
            return RedirectToAction("Index");
        }
    }
}
