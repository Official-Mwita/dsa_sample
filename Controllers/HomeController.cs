using DSA.Data;
using DSA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Text;

namespace DSA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ApplicationDbContext _db;

        //Holds a list of students
        private D_LinkedList studentList;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _db = db;
            _logger = logger;

            studentList = new D_LinkedList();
        }

        public IActionResult Index()
        {
            return View(3);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void GetStudents()
        {
            //On get without a parameter. Get data from the db
            IEnumerable<Student> students = _db.Student_DSA.ToList();

            foreach (Student student in students)
            {
                D_LinkedList.InsertNode(studentList, student);
            }

            //First traversal
            D_LinkedList.TraverseRight(studentList);
        }

        //Return a linked list of students starting from the current to the last and vice versa
        //Linked list is stored using session
        public IActionResult Students()
        {
            GetStudents();

            //Add list to session to facilitate traversal
            
            //string json = JsonConvert.SerializeObject(studentList);
            //byte[] data = Encoding.UTF8.GetBytes(json);
            //HttpContext.Session.SetInt32("s_list", 1);


            return View(studentList);
        }

        public JsonResult StudentsAPI()
        {
            var data = _db.Student_DSA.ToList();
            return new JsonResult(data);
        }



        //[HttpGet]
        //public IActionResult Students(string btn)
        //{
        //    //Get linked list from session otherwise create it. Then traverse
        //    //byte[] data;

        //    if(HttpContext.Session.GetInt32("s_list") == null 
        //        || HttpContext.Session.GetInt32("s_list") == 0) //Start or refress session
        //    {
        //        return Students();
        //    }
        //    else
        //    {
        //        GetStudents();
        //        int pointer = (int)HttpContext.Session.GetInt32("s_list") + 1;
        //        int i = 1;

        //        if (studentList.Current == null)
        //            return View(studentList);

        //        switch (btn)
        //        {
        //            case "next":
        //                while (studentList.Current.Next != null && i < pointer)
        //                {
        //                    D_LinkedList.TraverseRight(studentList);
        //                    i++;
        //                }
        //                break;

        //            case "prev":
        //                while (studentList.Current.Prev != null && i < pointer)
        //                {
        //                    D_LinkedList.TraverseLeft(studentList);
        //                    i++;
        //                }
        //                break;

        //            default:
        //                return Students();
        //        }

        //        HttpContext.Session.SetInt32("s_list", pointer);
        //    }

        //    //if (HttpContext.Session.TryGetValue("s_list", out data))
        //    //{
        //    //    data = HttpContext.Session.Get("s_list");
        //    //    string json = Encoding.UTF8.GetString(data);
        //    //    studentList = JsonConvert.DeserializeObject<D_LinkedList>(json);

        //    //}
        //    //else
        //    //{
        //    //    return Students();
        //    //}
        //    //    switch (btn)
        //    //{
        //    //    case "next":
        //    //        D_LinkedList.TraverseRight(studentList);
        //    //        break;

        //    //    case "prev":
        //    //        D_LinkedList.TraverseLeft(studentList);
        //    //        break;

        //    //    default:
        //    //           return Students();
        //    //}

        //    ////Write back to session
        //    //string json2 = JsonConvert.SerializeObject(studentList);
        //    //data = Encoding.UTF8.GetBytes(json2);
        //    //HttpContext.Session.Set("s_list", data);

            

        //    return View(studentList);
        //}

    }
}


/** Session controlled data
 * 
 * 
  //Get data from session or update using database
            int pointer;

            //if(HttpContext.Session.GetInt32("pointer") == null 
            //    || HttpContext.Session.GetInt32("pointer") == 0)
            //{
            //    pointer = 1;
            //    HttpContext.Session.SetInt32("pointer", pointer);
            //}
            //else
            //{
            //    pointer = (int)HttpContext.Session.GetInt32("pointer") + 1;
            //    HttpContext.Session.SetInt32("pointer", pointer);
            //}

            

            byte[] data;
            Student obj;

            if (!HttpContext.Session.TryGetValue("s_list", out data))
            {
                obj = new Student();

                //populate the object
                string json = JsonConvert.SerializeObject(obj);
                obj.Id = 1;
                data = Encoding.UTF8.GetBytes(json);
                HttpContext.Session.Set("s_list", data);
            }
            else
            {
                data = HttpContext.Session.Get("s_list");
                string json = Encoding.UTF8.GetString(data);
                obj = JsonConvert.DeserializeObject<Student>(json);
                obj.Id +=1;

                //Store back to session
                json = JsonConvert.SerializeObject(obj);
                data = Encoding.UTF8.GetBytes(json);
                HttpContext.Session.Set("s_list", data);
            }

 
 
 */