using CodingExercise.BAL.Classes;
using CodingExercise.BAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GridMvc;

namespace CodingExercise.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Setup.Initialize();
            try
            {
                List<PersonalDataModel> listdata = PersonalDataManager.GetAll();
                return View(listdata);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult Delete(string Id)
        {
            try
            {
                if(string.IsNullOrEmpty(Id))
                PersonalDataManager.Delete(Id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
            return RedirectToAction("Index");
        }
    }
}