using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.DtosLibrary
{
    public class RegisterDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Contactnumber { get; set; }
        public int Role { get; set; }
        public int YearOfExperience { get; set; }
        public String TrainerTechnology { get; set; }
    }
}
