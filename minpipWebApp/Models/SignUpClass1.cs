using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace minpipWebApp.Models
{
    public class SignUpClass1
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string Email { get; set; }
        public string Passwords { get; set; }
        public string Phone { get; set; }
        public System.DateTime DateRegister { get; set; }
        public int Active { get; set; }
    }
}