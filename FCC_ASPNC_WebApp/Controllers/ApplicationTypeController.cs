using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCC_ASPNC_WebApp.Data;
using FCC_ASPNC_WebApp.Models;

namespace FCC_ASPNC_WebApp.Controllers
{
    public class ApplicationTypeController : Controller
    {
        //Create variable for db instance
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// uses inbuilt depedency injection in ASP to obtain db on creating the controller for use within the controller
        /// </summary>
        /// <param name="db">instance of db context</param>
        public ApplicationTypeController(ApplicationDbContext db)
        {
            //assign db to instance variable
            _db = db;
        }


        /// <summary>
        /// return view for index action
        /// </summary>
        /// <returns>index view</returns>
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _db.ApplicationTypes;
            return View(objList);
        }

        //Action method for getting the Create Page
        public IActionResult Create()
        {
            return View();
        }


        // POST FOR CREATE
        // Defining method as a HTTP POST 
        [HttpPost]
        //Built in mechanism where it appends an anti forgery token and there are no security tampers
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            //Add new information to database
            _db.ApplicationTypes.Add(obj);
            //Commit to database 
            _db.SaveChanges();

            //Returns to Index action in this controller
            return RedirectToAction("Index");
        }

    }
}
