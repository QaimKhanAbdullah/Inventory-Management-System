using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;


namespace DBproject
{
    class DBClass
    {
        public static string constring
        {
            get { return ConfigurationManager.ConnectionStrings["constr"].ToString(); }
        }

        public static SqlConnection getsqlcon()
        {
            SqlConnection con = new SqlConnection(constring);
            return con;
        }

    }
}
