using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DizonCoop.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DizonCoop.Controllers
{
    public class ClientController : Controller
    {
        private readonly DizonCoopContext _context;

        public ClientController(DizonCoopContext client)
        {
            _context = client;
        }

        public IActionResult Index()
        {
           
            return View();


            
        }
        public ActionResult ModalCreate(){
            return PartialView("partials/_ModalCreate");
        }

        public ActionResult Table(){

            var client = _context.ClientInfos.ToList();
            return PartialView("partials/_PartialTable", client);
        }

    }
}