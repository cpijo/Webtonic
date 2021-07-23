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
    public class StudentsRepository : RepositoryBase<Students>, IStudentRepository
    {

        public override List<Students> GetAll()
        {

            command.CommandText = "SELECT * FROM [School].dbo.Students";
            return base.GetAll();
        }

        public override void SaveMany(List<Students> _model)
        {
            Delete(_model);
            command.CommandText = "INSERT INTO School.dbo.Students(StudentId,Firstname,Surname) values" +
                                    "(@StudentId,@Firstname,@Surname);";
            base.SaveMany(_model);
        }
        public override void Delete(List<Students> model)
        {
            List<Students> _model = model.GroupBy(x => x.StudentId).Select(x => x.First()).ToList();
            string userId = "";
            for (int i = 0; i < _model.Count(); i++)
                userId += "'" + _model[i].StudentId + "',";

            userId = userId.Substring(0, userId.LastIndexOf(','));
            command.CommandText = "DELETE FROM School.dbo.Students WHERE StudentId IN (" + userId + ")";
            base.Delete(_model);
        }

        public override Students PopulateRecord(SqlDataReader rows)
        {
            try
            {
                Students model1 = new Students();
                model1.StudentId = rows["StudentId"].ToString();
                model1.Firstname = rows["Firstname"].ToString();
                model1.Surname = rows["Surname"].ToString();

                return model1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override void command_ExecuteNonQuery(List<Students> _model)
        {
            foreach (var model in _model)
            {
                try
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("StudentId", model.StudentId);
                    command.Parameters.AddWithValue("@Firstname", model.Firstname);
                    command.Parameters.AddWithValue("@Surname", model.Surname);
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
