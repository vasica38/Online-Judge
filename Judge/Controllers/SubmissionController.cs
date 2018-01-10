using Judge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Judge.Controllers
{
    public class SubmissionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Submit(int submissionProblemId)
        {
            int id = submissionProblemId;

            Submission submission = new Submission
            {

            };
            List<string> languages = new List<string> { "C++", "C++14" };

            ViewBag.Languages = languages;
            return View();
        }



       // public ActionResult Submit(
    }
}