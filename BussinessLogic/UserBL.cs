using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;
using DataAccess;
using System.Data.SqlClient;
using System.Data;

namespace BussinessLogic
{
    public class UserBL
    {
        public SqlDataReader pbranch()
        {
            UserDA userda = new UserDA();
            return userda.Branch1();
        }

        public SqlDataReader level1()
        {
            UserDA userda = new UserDA();
            return userda.levelDA();
        }

        public SqlDataReader get_degree(UserBO  userbo)
        {
            UserDA userda = new UserDA();
            return userda.get_Degree(userbo);
        }

        public SqlDataReader get_branch(UserBO userbo)
        {
            UserDA userda = new UserDA();
            return userda.get_Branch(userbo);
        }

        public SqlDataReader get_duration(UserBO userbo)
        {
            UserDA userda = new UserDA();
            return userda.get_Duration(userbo);
        }

        public int save(UserBO userbo)
        {
            UserDA userda = new UserDA();
            return userda.save1(userbo);
        }

        public SqlDataReader show()
        {
            UserDA userda = new UserDA();
            return userda.display();
        }
        public string GetDegree(UserBO userbo)
        {
            UserDA userda = new UserDA();
            return userda.GetDegree1(userbo);
        }

        public string GetBranch(UserBO userbo)
        {
            UserDA userda = new UserDA();
            return userda.GetBranch1(userbo);
        }

        public string GetDuration(UserBO userbo)
        {
            UserDA userda = new UserDA();
            return userda.GetDuration1(userbo);
        }

        public int UpdateRec(UserBO userbo)
        {
            UserDA userda = new UserDA();
            return userda.UpdateRecord(userbo);
        }

        public SqlDataReader getPbranch(UserBO userBo)
        {
            UserDA userda = new UserDA();
            return userda.Pbranch(userBo);
        }
        public int getid(UserBO userbo)
        {
            UserDA userda = new UserDA();
            return userda.GetId(userbo);
        }
        public int Check(UserBO userbo)
        {
            UserDA userda = new UserDA();
            return userda.Varify(userbo);
        }
        public DataSet showexcel()
        {
            UserDA userda = new UserDA();
            return userda.excelshow();
        }

        public SqlDataReader updlist(UserBO userBo)
        {
            UserDA userda = new UserDA();
            return userda.Updlist(userBo);
        }

    }
}
