using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _3tireASP
{
    public class DataAccessLayer
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        public DataAccessLayer()
        {
            con=new SqlConnection(ConfigurationManager.AppSettings["dbconnection"]);
            //con.ConnectionString=ConfigurationManager.ConnectionStrings["dbconnection"].ToString();

        }
        public DataSet getDetails()
        {
            string query = "select * from login_details";
            da = new SqlDataAdapter(query, con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;

        }

        public void deleteDetils(tblproperty tp)
        {
           string query= "delete from login_details where login_id=@id";
           cmd = new SqlCommand(query, con);
           cmd.Parameters.AddWithValue("@id", tp.id);
           con.Open();
           cmd.ExecuteNonQuery();
           con.Close();
        }

        public void insertDetails(tblproperty tp)
        {
            string id = generateEMPID();
            string query = "insert into Login_Details values(@id,@Username,@pass)";
            cmd=new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@username", tp.Name);
            cmd.Parameters.AddWithValue("@pass", tp.Pass);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private string generateEMPID()
        {
            string query = "select max(convert(int,SUBSTRING(login_ID,4,LEN(login_ID)))) from Login_Details";
            con.Open();
            cmd = new SqlCommand(query, con);
            int i=(int)cmd.ExecuteScalar();
            con.Close();
            string ID="EMP"+(i+1);
            return ID;
        }



    }
}