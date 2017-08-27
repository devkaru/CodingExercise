using CodingExercise.BAL.Classes;
using CodingExercise.BAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingExercise.Controllers
{
    public class RegistrationController : Controller
    {

        // GET: Registration
        public ActionResult Index()
        {
            return View();


        }
        [HttpPost]
        public ActionResult Index(PersonalDataModel model)
        {
            try
            {
                Setup.Initialize();
                PersonalDataManager.Save(model);
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}