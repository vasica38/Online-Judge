using Judge.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Judge.Controllers
{
    public class SubmissionController : Controller
    {
        private int problemId = -1;
        ApplicationDbContext db = new ApplicationDbContext();

        public SubmissionController()
        {

        }
        // GET: Submission
        [HttpGet]
        public ActionResult Create(int submissionProblemId)
        {
            problemId = submissionProblemId;
            TempData["problemId"] = submissionProblemId;

            return View();
        }

        // GET: Submission/Details/5
        public ActionResult All()
        {
            if (db.Submissions.ToList() != null)
            {
                return View(db.Submissions.ToList());
            }
            else
            {
                return RedirectToRoute("Home");
            }
        }

        // POST: Submission/Create

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Submission submission = new Submission
                {
                    Code = collection["Code"],
                    Language = collection["Language"],
                    SubmissionAccountId = User.Identity.GetUserId(),
                    SubmissionProblemId = Int32.Parse(TempData["problemId"].ToString()),
                    Score = -1
                };

                db.Submissions.Add(submission);

                db.SaveChanges();

                return RedirectToAction("All");
            }
            catch
            {
                return View();
            }
        }

        // GET: Submission/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Submission/Edit/5
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

        // GET: Submission/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Submission/Delete/5
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
