using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Lotfi.HangFire.SimpleExample.Model;
using Microsoft.AspNetCore.Mvc;

namespace Lotfi.HangFire.SimpleExample.Controllers
{
    public class HomeController : Controller
    {
        private Lotfi1Context Context;

        public HomeController(Lotfi1Context context)
        {
            Context = context;
        }

        public IActionResult Index()
        {
            return View(Context.jobs.ToList());
        }
        public IActionResult StartJob()
        {
            RecurringJob.AddOrUpdate(() => AddJob(), Cron.Minutely);
            ViewData["Message"] = "Job Added.";
            return RedirectToAction("Index");
        }

        public void AddJob()
        {
            Context.jobs.Add(new myDate() { Date = DateTime.Now });
            Context.SaveChanges();
        }
    }
}