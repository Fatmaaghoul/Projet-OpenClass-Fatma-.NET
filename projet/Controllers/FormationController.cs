using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projet.Models;
using projet.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projet.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class FormationController : Controller
    {
        readonly IFormationRepository formationrepository;
        public FormationController(IFormationRepository formationrepository)
        {
            this.formationrepository = formationrepository;
        }

        // GET: FormationController
        [AllowAnonymous]

        public ActionResult Index()
        {
            return View(formationrepository.GetAll());
        }

        // GET: FormationController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.participantcount = formationrepository.ParticipantCount(id);

            var formation = formationrepository.GetById(id);
            return View(formation);
        }

        // GET: FormationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Formation s)
        {
            try
            {
                formationrepository.Add(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FormationController/Edit/5
        public ActionResult Edit(int id)
        {
            var formation = formationrepository.GetById(id);
            return View(formation);
        }

        // POST: FormationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Formation s)
        {
            try
            {
                formationrepository.Edit(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FormationController/Delete/5
        public ActionResult Delete(int id)
        {
            var formation = formationrepository.GetById(id);
            return View(formation);
        }

        // POST: FormationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Formation s)
        {
            try
            {
                formationrepository.Delete(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
