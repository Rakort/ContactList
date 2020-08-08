using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ContactList.Models;

namespace ContactList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Context db = new Context();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<Contact> contacts = db.Contacts;
            return View(contacts);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(db.Contacts.FirstOrDefault(f => f.Id == id) ?? new Contact());
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.Id == Guid.Empty)
                {
                    contact.Id = Guid.NewGuid();
                    db.Contacts.Add(contact);
                }
                else
                {
                    db.Contacts.Update(contact);
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(contact);
            }

        }

        [HttpGet]
        public ActionResult Remove(Guid id)
        {
            var contact = db.Contacts.FirstOrDefault(f => f.Id == id);
            if (contact != null)
            {
                db.Contacts.Remove(contact);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
