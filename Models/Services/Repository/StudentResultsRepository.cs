using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Webtonic.Models.Entities;
using Webtonic.Models.Services.Interface;

namespace Webtonic.Models.Services.Repository
{
    public class StudentResultsRepository : RepositoryBase<StudentResults>, IStudentResultsRepository
    {
        public override List<StudentResults> GetAll()
        {
            command.CommandText = "SELECT * FROM [School].dbo.StudentResults";
            return base.GetAll();
        }

        public override void SaveMany(List<StudentResults> _model)
        {
            Delete(_model);
            command.CommandText = "INSERT INTO School.dbo.StudentResults(StudentId,Firstname,Surname,CourseId,CourseName,Grade) values" +
                                    "(@StudentId,@Firstname,@Surname,@CourseId,@CourseName,@Grade)";
            base.SaveMany(_model);
        }

        public override void Delete(List<StudentResults> model)
        {
            List<StudentResults> _model = model.GroupBy(x => x.StudentId).Select(x => x.First()).ToList();
            string userId = "";
            for (int i = 0; i < _model.Count(); i++)
                userId += "'" + _model[i].StudentId + "',";

            userId = userId.Substring(0, userId.LastIndexOf(','));
            command.CommandText = "DELETE FROM School.dbo.StudentResults WHERE StudentId IN (" + userId + ")";
            base.Delete(_model);
        }

        public override StudentResults PopulateRecord(SqlDataReader rows)
        {
            try
            {
                StudentResults model = new StudentResults();
                model.StudentId = rows["StudentId"].ToString();
                model.Firstname = rows["Firstname"].ToString();
                model.Surname = rows["Surname"].ToString();
                model.CourseId = rows["CourseId"].ToString();
                model.CourseName = rows["CourseName"].ToString();
                model.Grade = rows["Grade"].ToString();
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override void command_ExecuteNonQuery(List<StudentResults> _model)
        {
            foreach (var model in _model)
            {
                try
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("StudentId", model.StudentId);
                    command.Parameters.AddWithValue("@Firstname", model.Firstname);
                    command.Parameters.AddWithValue("@Surname", model.Surname);
                    command.Parameters.AddWithValue("CourseId", model.CourseId);
                    command.Parameters.AddWithValue("@CourseName", model.CourseName);
                    command.Parameters.AddWithValue("@Grade", model.Grade);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch (Exception ex)
                {
                }
            }
        }

        private List<StudentResults> _StudentResults = new List<StudentResults>();
        public List<StudentResults> GetResults
        {
            get { return _StudentResults; }
            set { _StudentResults = value; }
        }
        public List<StudentResults> GetStundentsResults()
        {
            command.CommandText = "SELECT s.StudentId,s.Firstname,s.Surname,c.CourseId,c.CourseName,g.Grade " +
                               "FROM  School.dbo.Students  s " +
                               "INNER JOIN  School.dbo.Grades g ON g.StudentId = s.StudentId " +
                               "INNER JOIN  School.dbo.Courses c ON c.CourseId = g.CourseId " +
                               "Order By s.Surname asc ";
            return base.GetAll();
        }


    }
}
