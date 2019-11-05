using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VPM_Entity
{
    public class User
    {
        public string LogIn { get; set; }
        public string Password { get; set; }
        public string UserStatus { get; set; }
        public string EmailID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool  IsAdmin { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Sex { get; set; }
        public string MaritalStatus { get; set; }
        public string zipcode { get; set; }
        public DateTime  CreationDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string GroupID { get; set; }
        public string ContactNumber { get; set; }
    }
}
