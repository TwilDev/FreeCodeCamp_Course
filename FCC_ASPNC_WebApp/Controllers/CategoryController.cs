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

        // GET FOR CREATE 
        public IActionResult Create()
        {
            return View();
        }

        // POST FOR CREATE
        // Defining method as a HTTP POST 
        [HttpPost]
        //Built in mechanism where it appends an anti forgery token and there are no security tampers
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            //Checks if validation from model is met
            if (ModelState.IsValid)
            {
                //Add new information to database
                _db.Categories.Add(obj);
                //Commit to database 
                _db.SaveChanges();

                //Returns to Index action in this controller
                return RedirectToAction("Index");
            }
            // if validation not met simply return the view
            return View(obj);

        }

        // GET FOR EDIT - Takes id from the database element
        public IActionResult Edit(int id)
        {
            //validation for checking id has been retrieved successfully
            if(id==null || id == 0)
            {
                //if invalid return not found
                return NotFound();
            }
            //Create a new var an dassign a DB SELECT query passing in the ID as a parameter to search
            var obj = _db.Categories.Find(id);
            // if the null
            if (obj == null)
            {
                //return not found
                return NotFound();
            }
            // if all validation is met return the edit view and pass retrieved object over to it
            return View(obj);
        }


        // POST FOR EDIT
        // Defining method as a HTTP POST 
        [HttpPost]
        //Built in mechanism where it appends an anti forgery token and there are no security tampers
        [ValidateAntiForgeryToken]

        //if this is a complex object with several objects within it this will cause an error GO TO LINE 1 IN EDIT VIEW FOR EXPLANATION
        public IActionResult Edit(Category obj)
        {
            //Checks if validation from model is met
            if (ModelState.IsValid)
            {
                //Update information to database
                _db.Categories.Update(obj);
                //Commit to database 
                _db.SaveChanges();

                //Returns to Index action in this controller
                return RedirectToAction("Index");
            }
            // if validation not met simply return the view
            return View(obj);

        }


        // GET FOR DELETE - Takes id from the database element
        public IActionResult Delete(int id)
        {
            //validation for checking id has been retrieved successfully
            if (id == null || id == 0)
            {
                //if invalid return not found
                return NotFound();
            }
            //Create a new var an dassign a DB SELECT query passing in the ID as a parameter to search
            var obj = _db.Categories.Find(id);
            // if the null
            if (obj == null)
            {
                //return not found
                return NotFound();
            }
            // if all validation is met return the delete view and pass retrieved object over to it
            return View(obj);
        }

        // POST FOR DELETE
        // Defining method as a HTTP POST 
        [HttpPost]
        //Built in mechanism where it appends an anti forgery token and there are no security tampers
        [ValidateAntiForgeryToken]

        public IActionResult DeletePost(int CategoryId)
        {

            //Find db item with the associated ID   
            var obj = _db.Categories.Find(CategoryId);

            if (obj == null)
            {
                //return NotFound();
            }

            //Delete from database
            _db.Categories.Remove(obj);
            //Commit to database 
            _db.SaveChanges();
            //Returns to Index action in this controller
            return RedirectToAction("Index");

        }

    }
}
