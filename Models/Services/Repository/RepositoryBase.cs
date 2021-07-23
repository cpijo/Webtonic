using NetcarePortal.Models.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webtonic.Models.Entities;

namespace Webtonic.Models.Services.Interface
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        public SqlCommand command = null;
        public DataTable table = null;
        bool _isSuccess = true;
        public RepositoryBase()
        {
            command = new SqlCommand();
            command.CommandText = "";
            table = new DataTable();
        }

        public virtual List<T> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(DataBaseConnectorString.ConnectionString))
            {
                List<T> modelList = new List<T>();
                command.Connection = connection;

                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            T model = null;
                            model = PopulateRecord(reader);

                            modelList.Add(model);
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
                finally
                {
                    connection.Close(); ;
                }
                return modelList;
            }
        }

        public virtual void SaveMany(List<T> model)
        {
            using (SqlConnection connection = new SqlConnection(DataBaseConnectorString.ConnectionString))
            {
                command.Connection = connection;

                try
                {
                    //connection.Open();
                    command_ExecuteNonQuery(model);
                    _isSuccess = true;
                }
                catch (Exception ex)
                {
                    _isSuccess = false;
                }
                finally
                {
                    connection.Close(); ;
                }
            }
        }
        public virtual void Delete(List<T> model)
        {
            using (SqlConnection connection = new SqlConnection(DataBaseConnectorString.ConnectionString))
            {
                command.Connection = connection;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    _isSuccess = false;
                }
                finally
                {
                    connection.Close(); ;
                }
            }
        }

        public virtual T PopulateRecord(SqlDataReader reader)
        {
            return null;
        }
        public virtual void command_ExecuteNonQuery(List<T> model)
        {
            command.ExecuteNonQuery();
        }

    }
}
