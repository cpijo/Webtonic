using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webtonic.Models.Entities;
using Webtonic.Models.Services.Interface;
using Webtonic.Models.Services.Repository;

namespace Webtonic.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class StudentsResultsController : Controller
    {
        private IStudentResultsRepository studentResults;
        public StudentsResultsController(IStudentResultsRepository studentResults)
        {
            this.studentResults = studentResults;
        }

        #region View Student Results Page
        [HttpPost]
        public ActionResult ViewResults(string selectedValue)
        {
            List<StudentResults> studentList = studentResults.GetAll();
            return PartialView("_ViewStudentResults", studentList);
        }
        #endregion

        #region View Student Results Page
        [HttpGet]
        public ActionResult GetStudentResults(string email, string password)
        {
            List<StudentResults> studentList = studentResults.GetAll();
            return PartialView("_StudentResultsTable", studentList);
        }
        #endregion

        #region Add Student Results Page
        [HttpPost]
        public ActionResult UploadFile(FileModel model)
        {
            model.Destination = "Saving into StudentResults Table";
            return PartialView("_UploadFile", model);
        }
        #endregion

        #region Save Student Results 
        [HttpPost]
        public ActionResult SaveStudentResults(HttpPostedFileBase uploaFile)
        {
            if (uploaFile != null)
            {
                try
                {
                    string fileExtension = Path.GetExtension(uploaFile.FileName);
                    if (fileExtension != ".csv")
                    {
                        return Json(new { result = "false", message = "Please select the csv file with .csv extension", title = "Request Failed" }, JsonRequestBehavior.AllowGet);
                    }
                    List<StudentResults> srList = new List<StudentResults>();
                    using (var sreader = new StreamReader(uploaFile.InputStream))
                    {
                        string[] headers = sreader.ReadLine().Split(';');

                        while (!sreader.EndOfStream)
                        {
                            string[] rows = sreader.ReadLine().Split(';');

                            StudentResults sr = new StudentResults();
                            sr.StudentId = rows[0].ToString();
                            sr.Firstname = rows[1].ToString();
                            sr.Surname = rows[2].ToString();
                            sr.CourseId = rows[3].ToString();
                            sr.CourseName = rows[4].ToString();
                            sr.Grade = rows[5].ToString();
                            srList.Add(sr);
                        }
                    }

                    //List<StudentResults> _srList = srList.GroupBy(x => x.StudentId).Select(x => x.First()).ToList();
                    studentResults.SaveMany(srList);

                    return RedirectToAction("GetStudentResults", "StudentsResults");
                }
                catch (Exception ex)
                {
                    return Json(new { result = "false", message = ex.Message, title = "Request Failed" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                ViewBag.Message = "Please select the file first to upload.";
            }
            return null;
            #endregion
        }
    }
}