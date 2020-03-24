using System;
using System.Collections.Generic;

namespace StudentAPI.Models
{
    public partial class StudentMarks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? English { get; set; }
        public int? Maths { get; set; }
        public int? Science { get; set; }
    }
}
