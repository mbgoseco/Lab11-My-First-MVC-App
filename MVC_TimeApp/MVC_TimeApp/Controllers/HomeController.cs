using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_TimeApp.Models;

namespace MVC_TimeApp.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Displays the Index home view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Gathers data submitted to the form on the Index page and redirects it to the Results page.
        /// </summary>
        /// <param name="startYear">Year to search from</param>
        /// <param name="endYear">Year to search to</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(int startYear, int endYear)
        {
            return RedirectToAction("Results", new { startYear, endYear });
        }

        /// <summary>
        /// Calls the GetPersons method to create a list of people data based on the form search data, then renders the resuts on the Results view.
        /// </summary>
        /// <param name="startYear">Year to search from</param>
        /// <param name="endYear">Year to search to</param>
        /// <returns>table of people data</returns>
        [HttpGet]
        public IActionResult Results(int startYear, int endYear)
        {
            return View(TimePerson.GetPersons(startYear, endYear));
        }
    }
}
