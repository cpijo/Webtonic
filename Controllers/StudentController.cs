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
    public class StudentController : Controller
    {
        private IStudentResultsRepository studentResultsRepository;
        private IStudentRepository studentRepository;
        private ICoursesRepository courseRepository;
        private IGradesRepository gradesRepository;

        public StudentController(IStudentResultsRepository studentResultsRepository, IStudentRepository studentRepository,
            ICoursesRepository courseRepository, IGradesRepository gradesRepository)
        {
            this.studentResultsRepository = studentResultsRepository;
            this.studentRepository = studentRepository;
            this.courseRepository = courseRepository;
            this.gradesRepository = gradesRepository;
        }

        #region View Student Results Page
        [HttpGet]
        public ActionResult ViewResults()
        {
            List<StudentResults> studentList = studentResultsRepository.GetStundentsResults();
            return PartialView("_ViewStudentResults", studentList);
        }
        #endregion

        #region Get Student
        [HttpGet]
        public ActionResult GetStudentResults()
        {
            List<StudentResults> _model = studentResultsRepository.GetStundentsResults();
            return PartialView("_StudentResultsTable", _model);
        }
        #endregion

        #region Get Student
        [HttpGet]
        public ActionResult GetStudent()
        {
            List<Students> _model = studentRepository.GetAll();
            return PartialView("_StudentTable", _model);
        }
        #endregion

        #region Get Course
        [HttpGet]
        public ActionResult GetCourse()
        {
            List<Courses> model = courseRepository.GetAll();
            return PartialView("_CourseTable", model);
        }
        #endregion
        #region Get Grades
        [HttpGet]
        public ActionResult GetGrades()
        {
            List<Grades> model = gradesRepository.GetAll();
            return PartialView("_GradeTable", model);
        }
        #endregion

        #region Upload File
        [HttpPost]
        public ActionResult UploadFile(FileModel model)
        {
            model.Destination = "Saving into Student,Course And Grade Tables";
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

                    List<Students> students = new List<Students>();
                    List<Grades> grades = new List<Grades>();
                    List<Courses> courses = new List<Courses>();

                    List<string> sql_list = new List<string>();
                    List<string> sql_student_list = new List<string>();
                    List<string> sql_course_list = new List<string>();
                    List<string> sql_grade_list = new List<string>();

                    using (var sreader = new StreamReader(uploaFile.InputStream))
                    {
                        //This is the first line from the file as a header.
                        string[] headers = sreader.ReadLine().Split(';');

                        while (!sreader.EndOfStream)
                        {
                            string[] rows = sreader.ReadLine().Split(';');

                            students.Add(new Students
                            {
                                StudentId = rows[0].ToString(),
                                Firstname = rows[1].ToString(),
                                Surname = rows[2].ToString()
                            });
                            grades.Add(new Grades
                            {
                                StudentId = rows[0].ToString(),
                                CourseId = rows[3].ToString(),
                                Grade = rows[5].ToString()
                            });
                            courses.Add(new Courses
                            {
                                CourseId = rows[3].ToString(),
                                CourseName = rows[4].ToString()
                            });
                        }
                    }

                    List<Students> _students = students.GroupBy(x => x.StudentId).Select(x => x.First()).ToList();
                    List<Courses> _courses = courses.GroupBy(x => x.CourseId).Select(x => x.First()).ToList();
                    List<Grades> _grades = grades.GroupBy(x => new { x.CourseId, x.StudentId }).Select(x => x.First()).ToList();

                    studentRepository.SaveMany(_students);
                    courseRepository.SaveMany(_courses);
                    gradesRepository.SaveMany(_grades);

                    return RedirectToAction("GetStudentResults", "Student");
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