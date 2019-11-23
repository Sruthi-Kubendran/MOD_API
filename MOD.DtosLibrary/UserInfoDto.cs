using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.DtosLibrary
{
    public class UserInfoDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public bool Active { get; set; }
    }
}
