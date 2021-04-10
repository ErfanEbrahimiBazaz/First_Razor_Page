using FirstApp.Data;
using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.Controllers
{
    public class CountryController : Controller
    {
        private readonly DataContext _context;
        public CountryController( DataContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Country> countries = _context.Countries;
            return View(countries);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Country model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Country country = _context.Countries.SingleOrDefault(c => c.Id == id);
            return View(country);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Country model)
        {
            if (ModelState.IsValid)
            {
                _context.Countries.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Country country = _context.Countries.SingleOrDefault(c => c.Id == id);
            return View(country);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Country model)
        {
            _context.Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}
