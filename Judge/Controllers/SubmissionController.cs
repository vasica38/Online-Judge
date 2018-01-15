using Judge.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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

                string problemName = null;

                for(int i = 0; i < db.ProblemEntities.ToList().Count; ++i)
                {
                    if (db.ProblemEntities.ToList()[i].Id == submission.SubmissionProblemId)
                    {
                        problemName = db.ProblemEntities.ToList()[i].Name;
                        break;
                    }
                }

                if (null == problemName)
                {
                    problemName = "unknown";
                }
                else
                {
                    submission.ProblemName = problemName;
                }

                SendShit(submission);

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

        private void SendShit(Submission submission)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(new IPEndPoint(IPAddress.Parse("192.168.1.5"), 11000));
            var json = new JavaScriptSerializer().Serialize(submission);
            clientSocket.Send(Encoding.UTF8.GetBytes(json));
            clientSocket.Close();
        }
    }
}
