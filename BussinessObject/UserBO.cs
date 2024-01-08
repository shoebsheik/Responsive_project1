using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class UserBO
    {
        private string  _programee_branch;
        private string _level;
        private string _degree;
        private string _branch;
        private string _duration;
        private  string _intake;
        private int _id;

        public string Programee_branch
        {
            get
            {
                return _programee_branch;
            }
            set
            {
                _programee_branch = value;
            }
        }

        public string Level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
            }
        }

        public string Degree
        {
            get
            {
                return _degree;
            }
            set
            {
                _degree = value;
            }
        }

        public string Branch
        {
            get
            {
                return _branch;
            }
            set
            {
                _branch = value;
            }
        }

        public string Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
            }
        }

        public string Intake
        {
            get
            {
                return _intake;
            }
            set
            {
                _intake = value;
            }
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
    }
}
