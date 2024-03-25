using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DizonCoop.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Logging;

namespace DizonCoop.Controllers
{
    public class UserTypeController : Controller
    {
        private readonly DizonCoopContext _context;
        public UserTypeController(DizonCoopContext userType)
        {
            _context = userType;
            
        }

        public IActionResult Index()
        {   
            var userType = _context.UserTypes.ToList();
            return View(userType);
        }

        public IActionResult getTable()
        {   

            return PartialView("partialTable");
        }

    

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]

        public IActionResult Create(UserType usertype)
        {
            if(!ModelState.IsValid)
            return View(usertype);

            _context.UserTypes.Add(usertype);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id) {
            var userType = _context.UserTypes.Where( q => q.Id == id).FirstOrDefault();
            return View(userType);
        }

        [HttpPost]
        public IActionResult Update(UserType usertype) {

            if(!ModelState.IsValid)
                return View(usertype);

            _context.UserTypes.Update(usertype);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            var userType = _context.UserTypes.Where( q => q.Id == id).FirstOrDefault();
            _context.UserTypes.Remove(userType);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}