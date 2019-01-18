using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;
using WebApplication1.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PieManagementController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieManagementController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var pies = _pieRepository.Pies.OrderBy(p => p.Id);
            return View(pies);
        }

        public IActionResult AddPie()
        {
            var categories = _categoryRepository.Categories;
            var pieEditViewModel = new PieEditViewModel
            {
                Categories = categories.Select(c => new SelectListItem() { Text = c.CategoryName, Value = c.CategoryId.ToString() }).ToList(),
                CategoryId = categories.FirstOrDefault().CategoryId
            };
            return View(pieEditViewModel);
        }

        [HttpPost]
        public IActionResult AddPie(PieEditViewModel pieEditViewModel)
        {
            if (pieEditViewModel.Pie.Price < 0)
                ModelState.AddModelError(nameof(pieEditViewModel.Pie.Price), "The price of the pie should be higher than 0");

            
            if (ModelState.IsValid)
            {
                pieEditViewModel.Pie.CategoryId = pieEditViewModel.CategoryId;
                _pieRepository.CreatePie(pieEditViewModel.Pie);
                return RedirectToAction("Index");
            }

            return View(pieEditViewModel);
        }


        public IActionResult EditPie(int id)
        {
            var categories = _categoryRepository.Categories;

            var pie = _pieRepository.Pies.FirstOrDefault(p => p.Id == id);

            var pieEditViewModel = new PieEditViewModel
            {
                Categories = categories.Select(c => new SelectListItem() { Text = c.CategoryName, Value = c.CategoryId.ToString() }).ToList(),
                Pie = pie,
                CategoryId = pie.CategoryId
            };

            var item = pieEditViewModel.Categories.FirstOrDefault(c => c.Value == pie.CategoryId.ToString());
            item.Selected = true;

            return View(pieEditViewModel);
        }

        [HttpPost]
        public IActionResult EditPie(PieEditViewModel pieEditViewModel)
        {
            pieEditViewModel.Pie.CategoryId = pieEditViewModel.CategoryId;

            if (ModelState.IsValid)
            {
                _pieRepository.UpdatePie(pieEditViewModel.Pie);
                return RedirectToAction("Index");
            }
            return View(pieEditViewModel);
        }

        [HttpPost]
        public IActionResult DeletePie(int Id)
        {
            var pie = _pieRepository.GetPieById(Id);
            _pieRepository.DeletePie(pie);
            return View();
        }

     
    }
}
