using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKoll.Models;

namespace MVCKoll.Controllers
{
    public class HomeController : Controller
    {
        private static List<AdressViewModel> adresser = new List<AdressViewModel>();
        // GET: Adress
        public ActionResult Index()
        {
            return View(adresser);
        }

        // GET: Adress/Create
        public ActionResult Create()
        {
            return PartialView("_addAdress");
        }

        // POST: Adress/Create
        [HttpPost]
        public ActionResult Create(AdressViewModel model)
        {
            if (ModelState.IsValid) { 
            try
            {
                adresser.Add(new AdressViewModel {
                    id = Guid.NewGuid(),
                    Adress = model.Adress,
                    Name = model.Name,
                    Telefonnr = model.Telefonnr,
                    Date = DateTime.Now
                });

                return PartialView("_Result", adresser);
            }
            catch
            {
                return View();
            }
            } else
            {
                return PartialView("_Result", adresser);
            }
        }

        // GET: Adress/Edit/5
        public ActionResult Edit(Guid id)
        {
            var adress = adresser.Single(x => x.id == id);
            return PartialView("_Edit", adress);
        }

        public ActionResult Cancel(Guid id)
        {
            var adress = adresser.Single(x => x.id == id);
            return PartialView("_Cancel",adress);
        }

        public ActionResult CancelAdress()
        {
            return PartialView("_cancelAdress", adresser);
        }

        // POST: Adress/Edit/5
        [HttpPost]
        public ActionResult Edit(AdressViewModel model)
        {
            try
            {
                var oldAdress = adresser.Single(x => x.id == model.id);
                oldAdress.Name = model.Name;
                oldAdress.Adress = model.Adress;
                oldAdress.Telefonnr = model.Telefonnr;
                oldAdress.Date = DateTime.Now;

                return PartialView("_Cancel", oldAdress);
                
            }
            catch
            {
                return View();
            }
        }


        // POST: Adress/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                var oldAdress = adresser.Single(x => x.id == id);
                adresser.Remove(oldAdress);

                return PartialView("_Result", adresser);
            }
            catch
            {
                return View();
            }
        }
    }
}
