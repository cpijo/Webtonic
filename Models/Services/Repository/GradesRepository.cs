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
    public class GradesRepository : RepositoryBase<Grades>, IGradesRepository
    {
        public override List<Grades> GetAll()
        {
            command.CommandText = "SELECT * FROM School.dbo.Grades";
            return base.GetAll();
        }

        public override void SaveMany(List<Grades> model)
        {
            Delete(model);
            command.CommandText = "INSERT INTO School.dbo.Grades(CourseId,StudentId,Grade) values" +
                                "(@CourseId,@StudentId,@Grade);";
            base.SaveMany(model);
        }
        public override void Delete(List<Grades> model)
        {
            List<Grades> _model = model.GroupBy(x => x.StudentId).Select(x => x.First()).ToList();
            string userId = "";
            for (int i = 0; i < _model.Count(); i++)
                userId += "'" + _model[i].StudentId + "',";

            userId = userId.Substring(0, userId.LastIndexOf(','));
            command.CommandText = "DELETE FROM School.dbo.Grades WHERE StudentId IN (" + userId + ")";
            base.Delete(_model);
        }

        public override Grades PopulateRecord(SqlDataReader rows)
        {
            try
            {
                Grades model = new Grades();
                model.CourseId = rows["CourseId"].ToString();
                model.StudentId = rows["StudentId"].ToString();
                model.Grade = rows["Grade"].ToString();
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override void command_ExecuteNonQuery(List<Grades> _model)
        {
            foreach (var model in _model)
            {
                try
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("CourseId", model.CourseId);
                    command.Parameters.AddWithValue("@StudentId", model.StudentId);
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
    }
}
