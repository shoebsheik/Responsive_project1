using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
     public class uploadBO
    {
         private int _Roll;
         private string _Name;
         private int _College;
         private int _City;
         private string _Email;
         private string _DocName;
         private string _Filename;
         private int _Docid;
         private string _Path;

         public int Roll
         {
             get
             {
                 return _Roll;
             }
             set
             {
                 _Roll = value;
             }
         }

         public string Name
         {
             get
             {
                 return _Name;
             }
             set
             {
                 _Name = value;
             }
         }

         public int College
         {
             get
             {
                 return _College;
             }
             set
             {
                 _College = value;
             }
         }

         public int City
         {
             get
             {
                 return _City;
             }
             set
             {
                 _City = value;
             }
         }

         public string Email
         {
             get
             {
                 return _Email;
             }
             set
             {
                 _Email = value;
             }
         }

         public string DocName
         {
             get
             {
                 return _DocName;
             }
             set
             {
                 _DocName = value;
             }
         }

         public string FileName
         {
             get
             {
                 return _Filename;
             }
             set
             {
                 _Filename = value;
             }
         }

         public int DocId
         {
             get
             {
                 return _Docid;
             }
             set
             {
                 _Docid = value;
             }
         }

         public string Paths
         {
             get
             {
                 return _Path;
             }
             set
             {
                 _Path = value;
             }
         }
    }
}
