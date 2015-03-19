using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DIDemo.Business;
using DIDemo.Infrastructure;

namespace DIDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUoW uow;

        public HomeController(IUoW uow )
        {
            this.uow = uow;
        }

        public ActionResult Index()
        {
            var customerRepository = this.uow.GetRepository<Customer>();
            var customers = customerRepository.GetAll();

            return View(customers);
        }
    }
}
