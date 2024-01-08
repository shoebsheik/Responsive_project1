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
    public class UploadBL
    {
        public SqlDataReader show(uploadBO uploadbo) 
        {
            uploadDA uploadda = new uploadDA();
            return uploadda.showDetail(uploadbo);
        }

        public DataSet listdata(uploadBO uploadbo)
        {
            uploadDA uploadda = new uploadDA();
            return uploadda.ListDatas(uploadbo);
        }

        public int save(uploadBO uploadbo)
        {
            uploadDA uploadda = new uploadDA();
            return uploadda.SaveData(uploadbo);
        }

        public DataSet display(uploadBO uploadbo)
        {
            uploadDA uploadda = new uploadDA();
            return uploadda.DisplayList(uploadbo);
        }

        public SqlDataReader getfilepath(uploadBO uploadbo)
        {
            uploadDA uploadda = new uploadDA();
            return uploadda.getFilePath(uploadbo);
        }

        public DataSet display1(uploadBO uploadbo)
        {
            uploadDA uploadda = new uploadDA();
            return uploadda.AllData(uploadbo);
        }

        public int main1(uploadBO uploadbo)
        {
            uploadDA uploadda = new uploadDA();
            return uploadda.main(uploadbo);
        }
    }
}
