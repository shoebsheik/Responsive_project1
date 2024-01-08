using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;

namespace DataAccess
{
     public class uploadDA
    {

         public int res;
         public string result;
         public SqlDataReader showDetail(uploadBO uploadbo)
         {
               string connection = ConfigurationManager.ConnectionStrings["mydb1"].ConnectionString;
             SqlConnection con = new SqlConnection(connection);
             con.Open();
            
             SqlCommand cm = new SqlCommand("SP_GETSTUDENT",con );
             cm.CommandType = CommandType.StoredProcedure;
             cm.Parameters.AddWithValue("P_ROLL", uploadbo.Roll);
             return cm.ExecuteReader(); 
         }

         public DataSet ListDatas(uploadBO uploadbo)
         {
             string connection = ConfigurationManager.ConnectionStrings["mydb1"].ConnectionString;
             SqlConnection con = new SqlConnection(connection);
             con.Open();

             SqlCommand cm = new SqlCommand("SP_GETDOCUMENT", con);
             cm.CommandType = CommandType.StoredProcedure;
             cm.Parameters.AddWithValue("P_ROLL", uploadbo.Roll);
             SqlDataAdapter da = new SqlDataAdapter(cm);
             DataSet ds = new DataSet();
             da.Fill(ds, "FILEN"); 
             return ds ;
         }

         public int SaveData(uploadBO uploadbo)
         {
             string connection = ConfigurationManager.ConnectionStrings["mydb1"].ConnectionString;
             SqlConnection con = new SqlConnection(connection);
             con.Open();

             SqlCommand cm = new SqlCommand("SP_SAVE_DOC", con);
             cm.CommandType = CommandType.StoredProcedure;
             cm.Parameters.AddWithValue("P_ROLL",uploadbo.Roll);
             cm.Parameters.AddWithValue("P_DOC_ID", uploadbo.DocId);
             cm.Parameters.AddWithValue("P_FILENAME", uploadbo.FileName);
             cm.Parameters.AddWithValue("P_DOCNAME", uploadbo.DocName);
             return cm.ExecuteNonQuery();
         }

         public DataSet DisplayList(uploadBO uploadbo)
         {
             string connection = ConfigurationManager.ConnectionStrings["mydb1"].ConnectionString;
             SqlConnection con = new SqlConnection(connection);
             con.Open();

             SqlCommand cm = new SqlCommand("SP_LIST", con);
             cm.CommandType = CommandType.StoredProcedure;
             SqlDataAdapter da = new SqlDataAdapter(cm);
             DataSet ds = new DataSet();
             da.Fill(ds); 
            // SqlDataReader dr = cm.ExecuteReader();
             return ds;
         }

         public SqlDataReader getFilePath(uploadBO uploadbo)
        {
           string connection = ConfigurationManager.ConnectionStrings["mydb1"].ConnectionString;
             SqlConnection con = new SqlConnection(connection);
             con.Open();

             SqlCommand cm = new SqlCommand("SP_GETPATH", con);
             cm.CommandType = CommandType.StoredProcedure;
             cm.Parameters.AddWithValue("@P_FILENAME",uploadbo.FileName);
             SqlDataReader dr = cm.ExecuteReader();
             if (dr.Read())
             {
                 uploadbo.Paths = dr["FILEPATH"].ToString();
             }
             return dr;
        }

         public DataSet AllData(uploadBO uploadbo)
         {
             string connection = ConfigurationManager.ConnectionStrings["mydb1"].ConnectionString;
             SqlConnection con = new SqlConnection(connection);
             con.Open();

             SqlCommand cm = new SqlCommand("SP_GETDOCUMENT1", con);
             cm.CommandType = CommandType.StoredProcedure;    
             SqlDataAdapter da = new SqlDataAdapter(cm);
             DataSet ds = new DataSet();
             da.Fill(ds);
             return ds;
         }

         public int  main(uploadBO uploadbo)
         {
             string connection = ConfigurationManager.ConnectionStrings["mydb1"].ConnectionString;
             SqlConnection con = new SqlConnection(connection);
             con.Open();

             SqlCommand cm = new SqlCommand("SP_MAIN", con);
             cm.CommandType = CommandType.StoredProcedure;
             cm.Parameters.AddWithValue("P_ROLL", uploadbo.Roll);
             SqlDataReader dr = cm.ExecuteReader();
             if(dr.Read())
             {
                 res = 1;
             }
             else
             {
                 res = 0;
             }
             return res;  
         }
    }
}
