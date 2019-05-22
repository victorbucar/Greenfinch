using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Greenfinch.WebDeveloper.Data.Models;
using Greenfinch.WebDeveloper.Data.Interfaces;

namespace Greenfinch.WebDeveloper.Controllers
{
    public class NewslettersController : Controller
    {
        private readonly INewsletterRepository _newsletterRepository;
        

        public NewslettersController(INewsletterRepository newsletterRepository)
        {
            _newsletterRepository = newsletterRepository;
        }

        // GET: Newsletters
        public async Task<IActionResult> Index()
        {
            return View(await _newsletterRepository.GetAll());
        }

       
        // GET: Newsletters/Create
        public IActionResult Create()
        {
            var message = TempData["success"] as string;
            return View();
        }

        // POST: Newsletters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,HeardAbout,SignUpReason")] Newsletter newsletter)
        {
            if (ModelState.IsValid)
            {
                var isSubscribed = await _newsletterRepository.IsSubscribed(newsletter.Email);
                if(!isSubscribed)
                {
                    _newsletterRepository.Subscribe(newsletter);
                    await _newsletterRepository.SaveAll();
                    TempData["success"] = "Thank you for singning up to our newsletter";
                   
                    return RedirectToAction(nameof(Create));
                }
                ModelState.AddModelError("Email", "Email is already registered");
                return View(newsletter);
            }
            
            return View(newsletter);
        }

       
        //// GET: Newsletters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsletter = await _newsletterRepository.FindByIdAsync(id);
            if (newsletter == null)
            {
                return NotFound();
            }

            return View(newsletter);
        }

        // POST: Newsletters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsletter = await _newsletterRepository.FindByIdAsync(id);
            _newsletterRepository.Unsubscribe(newsletter);
            await _newsletterRepository.SaveAll();
            return RedirectToAction(nameof(Index));
        }

    }
}
