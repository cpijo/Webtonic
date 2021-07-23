using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NetcarePortal.Models.Data
{
    public class DataBaseConnectorString
    {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
    }
}