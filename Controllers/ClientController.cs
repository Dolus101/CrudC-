using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using DizonCoop.Entities;
using DizonCoop.Models;
using Microsoft.AspNetCore.Mvc;


namespace DizonCoop.Controllers
{
    public class ClientController : Controller
    {
        private readonly DizonCoopContext _context;

        public ClientController(DizonCoopContext context)
        {
            _context = context;

        }

        public async Task<IActionResult> Index()
        {
            var clientInfos = (
            from clientInfo in _context.ClientInfos
            join usertype in _context.UserTypes
            on clientInfo.Usertype equals usertype.Id
            select new ClientInfoViewModel
            {
                Id = clientInfo.Id,
                Usertype = clientInfo.Usertype,
                UsertypeName = usertype.Name,
                FirstName = clientInfo.FirstName,
                MiddleName = clientInfo.MiddleName,
                LastName = clientInfo.LastName,
                Address = clientInfo.Address,
                ZipCode = clientInfo.ZipCode,
                BirthDate = clientInfo.BirthDate,
                Age = clientInfo.Age,
                NameOfFather = clientInfo.NameOfFather,
                NameOfMother = clientInfo.NameOfMother,
                CivilStatus = clientInfo.CivilStatus,
                Relgion = clientInfo.Relgion,
                Occupation = clientInfo.Occupation,
            }
        ).ToList();

            return View(clientInfos);
            // ViewData["types"] =  _context.UserTypes.ToList();
            // ViewData["clientinfo"] = _context.ClientInfos.ToList();
            // return View();
        }

        [HttpPost]
        public ActionResult Create(ClientInfoViewModel clientinfo)
        {

            if (!ModelState.IsValid)
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
        public ActionResult Edit(ClientInfoViewModel clientinfo)
        {

            if (!ModelState.IsValid)
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

        // public ActionResult ModalUpdate(){
        //     return PartialView("partial/_ModalUpdate");
        // }

        public ActionResult ModalCreate()
        {
            return PartialView("partial/_ModalCreate");
        }

        public async Task<IActionResult> _ParitalTable(int? id)
        {
            if (id == null || _context.ClientInfos == null)
            {
                return NotFound();
            }

            var clientInfo = await _context.ClientInfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientInfo == null)
            {
                return NotFound();
            }

            return View(clientInfo);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var client = _context.ClientInfos.Where(q => q.Id == id).FirstOrDefault();
            _context.ClientInfos.Remove(client);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}