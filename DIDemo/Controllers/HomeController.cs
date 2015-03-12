using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DIDemo.Infrastructure;

namespace DIDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger logger;

        public HomeController(ILogger logger )
        {
            this.logger = logger;
        }

        public ActionResult Index()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            ViewBag.Title = "Home Page";

            stopWatch.Stop();

            this.logger.Log(string.Format("Time taken - {0}", stopWatch.Elapsed.TotalSeconds));
            
            return View();

            
        }
    }
}
