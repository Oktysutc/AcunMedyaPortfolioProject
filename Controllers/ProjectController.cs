using AcunMedyaPortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaPortfolioProject.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        PortfolioDbEntities db=new PortfolioDbEntities();
        public ActionResult Index()
        {
            var projects = db.Projects.ToList();
            return View(projects);
        }
        [HttpGet]
        public ActionResult CreateProject()
        {
            var categories=db.Categories.ToList();
            var list = new SelectList(categories,"Id","Name");
            ViewBag.categories = list;
            return View();
        }
        [HttpPost]
        public ActionResult CreateProject(Project project)
        {
            db.Projects.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}