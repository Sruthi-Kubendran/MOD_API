using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.Dtos
{
    class UserProfileDto
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Contactnumber { get; set; }
        public int YearOfExperience { get; set; }
        public String TrainerTechnology { get; set; }
    }
}
