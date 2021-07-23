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
    public class CoursesRepository : RepositoryBase<Courses>, ICoursesRepository
    {

        public override List<Courses> GetAll()
        {
            command.CommandText = "SELECT * FROM School.dbo.Courses";
            return base.GetAll();
        }

        public override void SaveMany(List<Courses> model)
        {
            Delete(model);
            command.CommandText = "INSERT INTO School.dbo.Courses(CourseId,CourseName)" +
                                " values(@CourseId,@CourseName);";            
            base.SaveMany(model);
        }
        public override void Delete(List<Courses> model)
        {
            List<Courses> _model = model.GroupBy(x => x.CourseId).Select(x => x.First()).ToList();
            string coursId = "";
            for (int i = 0; i < _model.Count(); i++)
                coursId += "'" + _model[i].CourseId + "',";

            coursId = coursId.Substring(0, coursId.LastIndexOf(','));
            command.CommandText = "DELETE FROM School.dbo.Courses WHERE CourseId IN (" + coursId + ")";
            base.Delete(_model);
        }

        public override Courses PopulateRecord(SqlDataReader rows)
        {
            try
            {
                Courses model = new Courses();
                model.CourseId = rows["CourseId"].ToString();
                model.CourseName = rows["CourseName"].ToString();
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override void command_ExecuteNonQuery(List<Courses> _model)
        {
            foreach (var model in _model)
            {
                try
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("CourseId", model.CourseId);
                    command.Parameters.AddWithValue("@CourseName", model.CourseName);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch (Exception ex)
                {
                }
            }
        }

    }
}
