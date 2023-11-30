using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSCI336_FinalProject.CSCI366FinalWork.Objects
{
    public class User
    {
        // Instance variables
        public int User_id { get; private set; }
        public string first_name { get; private set; }
        public string last_name { get; private set; }
        public bool is_Admin { get; private set; }
        public string email { get; private set; }
        public string username { get; private set; }
        public string password { get; private set; }

        // SQL Methods
        // REST OF SQL METHODS FOR USER CLASS ADDED HERE
    }
}