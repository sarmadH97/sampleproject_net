using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FileUploadExamples.Models;
using Microsoft.AspNetCore.Hosting;

using Microsoft.AspNetCore.Http;
using FileUploadExamples.ViewModels;
using System.IO;

namespace FileUploadExamples.Controllers
{
    public class DefaultController : Controller
    {
        StudentContext studentContext;
        IHostingEnvironment hostingEnvironment;
        public DefaultController(StudentContext context, IHostingEnvironment hosting)
        {
            studentContext = context;
            hostingEnvironment = hosting;
        }
        public IActionResult Index()
        {
            return View(studentContext.StudentDetails.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentDetailsViewModel studentDetails)
        {
            string filename = null;
            //string filepath = null;
            //if(studentDetails.Photo!=null)
            //{
            //    string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
            //    filename = Guid.NewGuid().ToString() + "_" + studentDetails.Photo.FileName;
            //    filepath = Path.Combine(uploadFolder, filename);
            //    studentDetails.Photo.CopyTo(new FileStream(filepath, FileMode.Create));
            //}

            //StudentDetails student = new StudentDetails()
            //{
            //    Sname = studentDetails.Sname,
            //    batch = studentDetails.batch,
            //    ImagePath = filename
            //};
            //studentContext.StudentDetails.Add(student);
            //studentContext.SaveChanges();


            if (studentDetails.Photo != null && studentDetails.Photo.Count>0)
            {
                foreach (IFormFile item in studentDetails.Photo)
                {
                    string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    filename = Guid.NewGuid().ToString() + "_" + item.FileName;
                    string filepath = Path.Combine(uploadFolder, filename);
                    item.CopyTo(new FileStream(filepath, FileMode.Create));

                    StudentDetails student = new StudentDetails()
                    {
                        Sname = studentDetails.Sname,
                        batch = studentDetails.batch,
                        ImagePath = filename
                    };
                    studentContext.StudentDetails.Add(student);
                }

                
            }

          
            studentContext.SaveChanges();
            return View();
        }
    }
}