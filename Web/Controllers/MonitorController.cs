using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication6.Controllers
{
    public class MonitorController : Controller
    {
        // GET: Monitor/Random
        public class Lal
        {
           public string Name { set; get; }
        }
        public ActionResult All()
        {
            /**
             * Get from repository all submission
             */

            Lal lal = new Lal { Name = "lol" };
            return View(lal);
        }
    }
}