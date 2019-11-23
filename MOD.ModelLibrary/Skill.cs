using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.ModelLibrary
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TOC { get; set; }
        public int Fees { get; set; }
        public string Prerequisites { get; set; }
    }
}
