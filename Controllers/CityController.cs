using FirstApp.Data;
using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.Controllers
{
    public class CityController : Controller
    {
        private readonly DataContext _context;
        public CityController(DataContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<City> cities = _context.Cities.Include(c => c.Country);
            return View(cities);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CountryId = _context.Countries.Select(x => new SelectListItem
            {
                Text = x.CountryName,
                Value = x.Id.ToString()
            }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(City model)
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
            ViewBag.CountryId = _context.Countries.Select(x => new SelectListItem
            {
                Text = x.CountryName,
                Value = x.Id.ToString()
            }).ToList();
            City city = _context.Cities.SingleOrDefault(c => c.Id == id);
            return View(city);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(City model)
        {
            ViewBag.CountryId = _context.Countries.Select(x => new SelectListItem
            {
                Text = x.CountryName,
                Value = x.Id.ToString()
            }).ToList();

            if (ModelState.IsValid)
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            City city = _context.Cities.SingleOrDefault(c => c.Id == id);
            _context.Remove(city);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
