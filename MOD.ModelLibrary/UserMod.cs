using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.ModelLibrary
{
    public class UserMod : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int YearOfExperience { get; set; }
        public string TrainerTechnology { get; set; }
        public bool Active { get; set; } = true;
        public bool ConfirmSignup { get; set; }
        public string PictureUrl { get; set; }
        public string TrainerTimings { get; set; }
        public string RegCode { get; set; }
    }
}
