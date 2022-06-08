using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projet.Models;
using projet.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projet.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class ParticipantController : Controller
    {
        readonly IParticipantRepository participantrepository;
        readonly IFormationRepository formationrepository;

        public ParticipantController(IParticipantRepository participantrepository, IFormationRepository formationrepository)
        {
            this.participantrepository = participantrepository;
            this.formationrepository = formationrepository;
        }

        [AllowAnonymous]
        // GET: ParticipantController
        public ActionResult Index()
        {
            ViewBag.FormationID = new SelectList(formationrepository.GetAll(), "FormationID", "FormationName");
            return View(participantrepository.GetAll());
        }

        // GET: ParticipantController/Details/5
        public ActionResult Details(int id)
        {
            return View(participantrepository.GetById(id));
        }

        // GET: ParticipantController/Create
        public ActionResult Create()
        {
            ViewBag.FormationID = new SelectList(formationrepository.GetAll(), "FormationID", "FormationName");
            return View();
        }

        // POST: ParticipantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Participant s)
        {
            try
            {
                ViewBag.FormationID = new SelectList(formationrepository.GetAll(), "FormationID", "FormationName", s.FormationID);
                participantrepository.Add(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParticipantController/Edit/5
        public ActionResult Edit(int id)
        {

            ViewBag.FormationID = new SelectList(formationrepository.GetAll(), "FormationID", "FormationName");
            return View(participantrepository.GetById(id));
        }

        //Search
        public ActionResult Search(string name, int? formationid)
        {
            var result = participantrepository.GetAll();
            if (!string.IsNullOrEmpty(name))
                result = participantrepository.FindByName(name);
            else
            if (formationid != null)
                result = participantrepository.GetParticipantsByFormationID(formationid);
                ViewBag.FormationID = new SelectList(formationrepository.GetAll(), "FormationID", "FormationName");
                return View("Index", result);
        }


        // POST: ParticipantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Participant s)
        {
            try
            {
                ViewBag.FormationID = new SelectList(formationrepository.GetAll(), "FormationID", "FormationName", s.FormationID);
                participantrepository.Edit(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParticipantController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(participantrepository.GetById(id));
        }

        // POST: ParticipantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Participant s)
        {
            try
            {
                participantrepository.Delete(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
