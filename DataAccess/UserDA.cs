using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;
using System.Security.Cryptography.X509Certificates;
namespace DataAccess
{
    public class UserDA
    {
        public string res;
        public int result;
        public SqlDataReader Branch1()
        {
            string connection = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cm = new SqlCommand("SP_PROGRAMEE1", con);
            cm.CommandType = CommandType.StoredProcedure;
            return cm.ExecuteReader(); 

        }

        public SqlDataReader levelDA()
        {
            string connection = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cm = new SqlCommand("SP_GET_LEVEL", con);
            cm.CommandType = CommandType.StoredProcedure;
            return cm.ExecuteReader();
        }

        public SqlDataReader get_Degree(UserBO userbo)
        {
            string connection = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cm = new SqlCommand("SP_GET_DEGREE", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("P_LEVEL", userbo.Level);
            return cm.ExecuteReader();
        }

        public SqlDataReader get_Branch(UserBO userbo)
        {
            string connection = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cm = new SqlCommand("SP_GET_BRANCH", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("P_DEGREE", userbo.Degree);
            return cm.ExecuteReader();
        }

        public SqlDataReader get_Duration(UserBO userbo)
        {
            string connection = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cm = new SqlCommand("SP_GET_DURATION", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("P_DEGREE", userbo.Degree);
            return cm.ExecuteReader();
        }

        public int save1(UserBO userbo)
        {
            string connection = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cm = new SqlCommand("SP_SAVE_DATA", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("P_PROGRAME", userbo.Programee_branch);
            cm.Parameters.AddWithValue("P_LEVEL", userbo.Level);
            cm.Parameters.AddWithValue("P_DEGREE", userbo.Degree);
            cm.Parameters.AddWithValue("P_BRANCH", userbo.Branch);
            cm.Parameters.AddWithValue("P_DURATION", userbo.Duration);
            cm.Parameters.AddWithValue("P_INTAKE", userbo.Intake);
            return cm.ExecuteNonQuery();

        }

        public SqlDataReader display()
        {
            string connection = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cm = new SqlCommand("SP_DISPLAY", con);
            cm.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cm.ExecuteReader();
            return dr;
        }

        public string GetDegree1(UserBO userbo)
        {
           
            string connection = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cm = new SqlCommand("SP_SET_DEGREE", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("P_ID", userbo.Id);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read()) {
               res  = dr["DEGREE"].ToString();
            }
            return res;
        }

        public string GetBranch1(UserBO userbo)
        {

            string connection = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cm = new SqlCommand("SP_SET_BRANCH", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("P_ID", userbo.Id);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
            {
                res = dr["BRANCH"].ToString();
            }
            return res;
        }

        public string GetDuration1(UserBO userbo)
        {

            string connection = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cm = new SqlCommand("SP_SET_DURATION", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("P_ID", userbo.Id);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
            {
                res = dr["DURATION"].ToString();
            }
            return res;
        }

        public int UpdateRecord(UserBO userbo)
        {
            string connection = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cm = new SqlCommand("SP_UPDATE_DATA", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("P_ID", userbo.Id);
            cm.Parameters.AddWithValue("P_PROGRAME", userbo.Programee_branch);
            cm.Parameters.AddWithValue("P_LEVEL", userbo.Level);
            cm.Parameters.AddWithValue("P_DEGREE", userbo.Degree);
            cm.Parameters.AddWithValue("P_BRANCH", userbo.Branch);
            cm.Parameters.AddWithValue("P_DURATION", userbo.Duration);
            cm.Parameters.AddWithValue("P_INTAKE", userbo.Intake);
            return cm.ExecuteNonQuery();

        }

        public SqlDataReader Pbranch(UserBO userBo)
        {
            string connection = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cm = new SqlCommand("SP_PBRANCH_DATA", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("P_Branch", userBo.Programee_branch);
            SqlDataReader dr = cm.ExecuteReader();
            return dr;
        }

        public int GetId(UserBO userbo) 
        {
            string connection = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cm = new SqlCommand("SP_GETID", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("P_PROGRAME", userbo.Programee_branch);
            cm.Parameters.AddWithValue("P_LEVEL", userbo.Level);
            cm.Parameters.AddWithValue("P_DEGREE", userbo.Degree);
            cm.Parameters.AddWithValue("P_BRANCH", userbo.Branch);
            cm.Parameters.AddWithValue("P_DURATION", userbo.Duration);
            cm.Parameters.AddWithValue("P_INTAKE", userbo.Intake);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
            {
                result =Convert.ToInt32(dr["ID"].ToString());
            }
            return result;
        }

        public int Varify(UserBO userbo)
        {
            string connection = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cm = new SqlCommand("SP_VARIFY1", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("P_PROGRAME", userbo.Programee_branch);
            cm.Parameters.AddWithValue("P_LEVEL", userbo.Level);
            cm.Parameters.AddWithValue("P_DEGREE", userbo.Degree);
            cm.Parameters.AddWithValue("P_BRANCH", userbo.Branch);
            cm.Parameters.AddWithValue("P_DURATION", userbo.Duration);
            cm.Parameters.AddWithValue("P_INTAKE", userbo.Intake);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
            {
                result = 1;
            }
            return result;
        }

        public DataSet excelshow()
        {
            string connection = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cm = new SqlCommand("SP_EXCEL", con);
            cm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adp = new SqlDataAdapter(cm);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds;
        }

        public SqlDataReader Updlist(UserBO userbo)
        {
            string connection = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cm = new SqlCommand("SP_GETLIST", con);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("P_ID", userbo.Id);
            return cm.ExecuteReader();
        }
    }
}
