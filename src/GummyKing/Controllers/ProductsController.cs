using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GummyKing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GummyKing.Controllers
{
    public class ProductsController : Controller
    {

        private GummyKingDbContext db = new GummyKingDbContext();
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Products.Include(p => p.Country).ToList());
        }

        //Get - Product Details
        public IActionResult Details(int id)
        {
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            var thisProd = db.Products.FirstOrDefault(p => p.ProductId == id);
            return View(thisProd);
        }

        //POST - Update Products - in Details
        [HttpPost, ActionName("Save")]
        public IActionResult Details(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get - Products Create
        public IActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            return View();
        }

        // Post - Products Create
        [HttpPost]
        public IActionResult Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get - Update Products
        //public IActionResult Update(int id)
        //{
        //    ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
        //    var thisProd = db.Products.FirstOrDefault(p => p.ProductId == id);
        //    return View(thisProd);
        //}


        //Get Delete Product
        //public IActionResult Delete(int id)
        //{
        //    var thisProd = db.Products.FirstOrDefault(p => p.ProductId == id);
        //    return View(thisProd);
        //}

        //POST - Delete Product
        [HttpPost, ActionName("Details")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisProd = db.Products.FirstOrDefault(p => p.ProductId == id);
            db.Products.Remove(thisProd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
