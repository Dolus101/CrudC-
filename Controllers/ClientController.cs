using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DizonCoop.Entities;
using DizonCoop.Models;
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
            ViewData["types"] =  _context.UserTypes.ToList();
            ViewData["clientinfo"] = _context.ClientInfos.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClientInfoViewModel clientinfo){

            if(!ModelState.IsValid)
            return View(clientinfo);

            ClientInfo c = new ClientInfo
            {
                Id = clientinfo.Id,
                Usertype = clientinfo.Usertype,
                FirstName = clientinfo.FirstName,
                MiddleName = clientinfo.MiddleName,
                LastName = clientinfo.LastName,
                Address = clientinfo.Address,
                ZipCode = clientinfo.ZipCode,
                BirthDate = clientinfo.BirthDate,
                Age = clientinfo.Age,
                NameOfFather = clientinfo.NameOfFather,
                NameOfMother = clientinfo.NameOfMother,
                CivilStatus = clientinfo.CivilStatus,
                Relgion = clientinfo.Relgion,
                Occupation = clientinfo.Occupation
            };

            _context.ClientInfos.Add(c);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

                [HttpPost]
        public ActionResult Edit(ClientInfoViewModel clientinfo){

            if(!ModelState.IsValid)
            return View(clientinfo);

            ClientInfo s = new ClientInfo
            {
                Id = clientinfo.Id,
                Usertype = clientinfo.Usertype,
                FirstName = clientinfo.FirstName,
                MiddleName = clientinfo.MiddleName,
                LastName = clientinfo.LastName,
                Address = clientinfo.Address,
                ZipCode = clientinfo.ZipCode,
                BirthDate = clientinfo.BirthDate,
                Age = clientinfo.Age,
                NameOfFather = clientinfo.NameOfFather,
                NameOfMother = clientinfo.NameOfMother,
                CivilStatus = clientinfo.CivilStatus,
                Relgion = clientinfo.Relgion,
                Occupation = clientinfo.Occupation
            };

            _context.ClientInfos.Update(s);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }





        // [HttpGet]
        // public ActionResult Update(int id)
        // {
        //     var client = _context.ClientInfos
        //                     .Where(q => q.Id == id )
        //                     .Select(s => new ClientInfoViewModel {
        //                         Id = s.Id,
        //                         Usertype = s.Usertype,
        //                         FirstName = s.FirstName,
        //                         MiddleName = s.MiddleName,
        //                         LastName = s.LastName,
        //                         Address = s.Address,
        //                         ZipCode = s.ZipCode,
        //                         BirthDate = s.BirthDate,
        //                         Age = s.Age,
        //                         NameOfFather = s.NameOfFather,
        //                         NameOfMother = s.NameOfMother,
        //                         CivilStatus = s.CivilStatus,
        //                         Relgion = s.Relgion,
        //                         Occupation = s.Occupation
        //                     })
        //                     .FirstOrDefault();
        //     return RedirectToAction("Index");
        // }

        // [HttpPost]
        // public ActionResult Update(ClientInfoViewModel clientinfo) {

        //     if(!ModelState.IsValid)
        //     return View(clientinfo);

        //     ClientInfo c = new ClientInfo
        //     {
        //         Id = clientinfo.Id,
        //         Usertype = clientinfo.Usertype,
        //         FirstName = clientinfo.FirstName,
        //         MiddleName = clientinfo.MiddleName,
        //         LastName = clientinfo.LastName,
        //         Address = clientinfo.Address,
        //         ZipCode = clientinfo.ZipCode,
        //         BirthDate = clientinfo.BirthDate,
        //         Age = clientinfo.Age,
        //         NameOfFather = clientinfo.NameOfFather,
        //         NameOfMother = clientinfo.NameOfMother,
        //         CivilStatus = clientinfo.CivilStatus,
        //         Relgion = clientinfo.Relgion,
        //         Occupation = clientinfo.Occupation
        //     };

        //     _context.ClientInfos.Update(c);
        //     _context.SaveChanges();

        //     return RedirectToAction("Index");
        // }

        public ActionResult ModalUpdate(){
            return PartialView("partial/_ModalUpdate");
        }

        public ActionResult ModalCreate(){
            return PartialView("partial/_ModalCreate");
        }

        public ActionResult Table(){

            
            return PartialView("partial/_PartialTable");
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            var client = _context.ClientInfos.Where( q => q.Id == id).FirstOrDefault();
            _context.ClientInfos.Remove(client);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}