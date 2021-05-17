using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCC_ASPNC_WebApp.Data;
using FCC_ASPNC_WebApp.Models;

namespace FCC_ASPNC_WebApp.Controllers
{
    /// <summary>
    /// Controller for Category Table in SQLServer
    /// </summary>
    public class CategoryController : Controller
    {
        //Create variable for db instance
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// uses inbuilt depedency injection in ASP to obtain db on creating the controller for use within the controller
        /// </summary>
        /// <param name="db">instance of db context</param>
        public CategoryController(ApplicationDbContext db)
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
            IEnumerable<Category> objList = _db.Categories;
            return View(objList);
        }
    }
}
