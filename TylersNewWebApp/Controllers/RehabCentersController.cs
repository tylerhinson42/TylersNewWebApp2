using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TylersNewWebApp.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TylersNewWebApp.Controllers
{
    public class RehabCentersController : Controller
    {
        private readonly IRehabCentersRepository repo;

        public RehabCentersController(IRehabCentersRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult ViewRehabCenters(int id)
        {
            var rehabCenters = repo.GetRehabCenters(id);

            return View(rehabCenters);
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var rehabCenters = repo.GetAllRehabCenters();

            return View(rehabCenters);
        }

        public IActionResult UpdateRehabCentersToDatabase(RehabCenters rehabCenters)
        {
            repo.UpdateRehabCenters(rehabCenters);

            return RedirectToAction("ViewRehabCenters", new { id = rehabCenters.ID });
        }

        public IActionResult UpdateProduct(int id)
        {
            RehabCenters rehab = repo.GetRehabCenters(id);

            repo.UpdateRehabCenters(rehab);

            if (rehab == null)
            {
                return View("ProductNotFound");
            }

            return View(rehab);
        }


        public IActionResult InsertRehabCenters()
        {
            var rehab = new RehabCenters();
            return View(rehab);
        }

        public IActionResult InsertRehabCentersToDatabase(RehabCenters rehabCentersToInsert)
        {
            repo.InsertRehabCenters(rehabCentersToInsert);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteRehabCenters(RehabCenters rehabCenters)
        {
            repo.DeleteRehabCenters(rehabCenters);

            return RedirectToAction("Index");
        }

    }
}
