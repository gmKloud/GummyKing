using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GummyKing.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GummyKing.Controllers
{
    public class ProductsController : Controller
    {

        private GummyKingDbContext db = new GummyKingDbContext();
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Products.ToList());
        }

        //Get - Product Details
        public IActionResult Details(int id)
        {
            var thisProd = db.Products.FirstOrDefault(p => p.ProductId == id);
            return View(thisProd);
        }

        //Get - Products Create
        public IActionResult Create()
        {
            return View();
        }

        // Post - Products Create
        public IActionResult Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get - Update Products
        public IActionResult Update(int id)
        {
            var thisProd = db.Products.FirstOrDefault(p => p.ProductId == -id);
            return View(thisProd);
        }

        //POST - Update Products
        [HttpPost]
        public IActionResult Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get Delete Product
        public IActionResult Delete(int id)
        {
            var thisProd = db.Products.FirstOrDefault(p => p.ProductId == id);
            return (thisProd);
        }

        //POST - Delete Product
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteCondfirmed(int id)
        {
            var thisProd = db.Products.FirstOrDefault(p => p.ProductId == id);
            db.Products.Remove(thisProd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
