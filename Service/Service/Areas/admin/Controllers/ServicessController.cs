using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Areas.admin.Controllers
{
    [Area("admin")]
    public class ServicessController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ServicessController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View(_context.Services.ToList());
        }

        public IActionResult Create()
        {
            //ViewBag.Users = _context.Users.ToList();
            //ViewBag.Categories = _context.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Service.Models.Service model)
        {

            if (ModelState.IsValid)
            {
                if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png")
                {
                    if (model.ImageFile.Length <= 3145728)
                    {
                        string fileName = Guid.NewGuid() + "-" + model.ImageFile.FileName;
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            model.ImageFile.CopyTo(stream);
                        }

                        model.Image = fileName;
                        _context.Services.Add(model);
                        _context.SaveChanges();

                        return RedirectToAction("index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "You can only upload max 3 mb file!");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "You can only upload image file!");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }


        public IActionResult Update(int? id)
        {
            return View(_context.Services.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Service.Models.Service model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png")
                    {
                        if (model.ImageFile.Length <= 3145728)
                        {
                            string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", model.Image);
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }

                            string fileName = Guid.NewGuid() + "-" + model.ImageFile.FileName;
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }

                            model.Image = fileName;

                            _context.Services.Update(model);
                            _context.SaveChanges();

                            return RedirectToAction("index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "You can only upload max 3 mb file!");
                            return View(model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "You can only upload image file!");
                        return View(model);
                    }
                }
                else
                {
                    _context.Services.Update(model);
                    _context.SaveChanges();
                    return RedirectToAction("index");
                }
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Service.Models.Service service = _context.Services.Find(id);
            if (service == null)
            {
                return NotFound();
            }

            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", service.Image);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            _context.Services.Remove(service);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
    

