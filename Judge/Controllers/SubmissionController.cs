using Judge.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Judge.Controllers
{
    public class NewSubmission
    {
        public NewSubmission(Submission submission)
        {
            Id = submission.Id;
            Score = submission.Score;
            Code = submission.Code;
            Language = submission.Language;
            SubmissionAccountId = submission.SubmissionAccountId;
            SubmissionProblemId = submission.SubmissionProblemId;
            ProblemName = submission.ProblemName;
        }

        public int Id { get; set; }
        public int Score { get; set; }
        public string Code { get; set; }
        public string Language { get; set; }
        public string SubmissionAccountId { get; set; }
        public int SubmissionProblemId { get; set; }
        public string ProblemName { get; set; }
        public string UserName { get; set; }


    }

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

        [HttpPost, ValidateInput(false)]
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

                    Score = 100
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

                Send(submission);
                Thread.Sleep(2500);

                db.Submissions.Add(submission);

                db.SaveChanges();

                return RedirectToAction("All");
            }
            catch
            {
                RedirectToAction("All");
            }

            return RedirectToAction("All");
        }


        public ActionResult Problem(int problemId)
        {
            List<NewSubmission> submissions = new List<NewSubmission>();


            for (int i = 0; i < db.Submissions.ToList().Count; ++i)
            {
              
                if (db.Submissions.ToList()[i].SubmissionProblemId == problemId)
                {
                    NewSubmission submission = new NewSubmission(db.Submissions.ToList()[i]);
                    for(int j = 0; j < db.Users.ToList().Count; ++i)
                    {
                        if (db.Users.ToList()[j].Id == submission.SubmissionAccountId)
                        {
                            submission.UserName = db.Users.ToList()[j].UserName;
                            break;
                        }
                    }
                    submissions.Add(submission);
                }
            }


            return View(submissions);
        }

        public ActionResult View(int submissionId)
        {
            for (int i = 0; i < db.Submissions.ToList().Count; ++i)
            {
                if(db.Submissions.ToList()[i].Id == submissionId)
                {
                    NewSubmission submission = new NewSubmission(db.Submissions.ToList()[i]);
                    for (int j = 0; j < db.Users.ToList().Count; ++i)
                    {
                        if (db.Users.ToList()[j].Id == submission.SubmissionAccountId)
                        {
                            submission.UserName = db.Users.ToList()[j].UserName;
                            return View(submission);
                        }
                    }
                    break;
                }
            }
            return View();
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

        private void Send(Submission submission)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000));
            var json = new JavaScriptSerializer().Serialize(submission);
            clientSocket.Send(Encoding.UTF8.GetBytes(json));
            clientSocket.Close();
        }

       
    }
}
