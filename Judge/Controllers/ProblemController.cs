using Judge.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Judge.Controllers
{
    [Authorize]
    public class ProblemController : Controller
    {
        // GET: Problem
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            if (db.ProblemEntities.ToList()!=null)
            {
                return View(db.ProblemEntities.ToList());

            }
            else
            {
                return HttpNotFound("No problems");
            }
        }

        // GET: Problem/Details/5
        public ActionResult Details(int id = 1, string name = "vasiok")
        {
            ProblemEntity problem = null;

            for(int i = 0; i <db.ProblemEntities.ToList().Count; ++i)
            {
                if (db.ProblemEntities.ToList()[i].Id == id || db.ProblemEntities.ToList()[i].Name == name)
                {
                    problem = db.ProblemEntities.ToList()[i];
                    break;
                }
            }

            if (problem != null)
            {
                return View(problem);
            }

            return HttpNotFound("Not such a problem");
        }

        // GET: Problem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Problem/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var db = new ApplicationDbContext();

                ProblemEntity problem = new ProblemEntity
                {
                    Author = collection["Author"],
                    In = collection["In"],
                    Out = collection["Out"],
                    MemoryLimitKb = Int32.Parse(collection["MemoryLimitKb"].ToString()),
                    TymeLimitMs = Int32.Parse(collection["TymeLimitMs"].ToString()),
                    Name = collection["Name"],
                    Text = collection["Text"],
                    ApplicationUserId = User.Identity.GetUserId()
                };

                db.ProblemEntities.Add(problem);
                db.SaveChanges();

                return RedirectToAction("Details", new { id = problem.Id } );
            }
            catch
            {
                return View();
            }
        }

        // GET: Problem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Problem/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Problem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Problem/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
