using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Students.Business.Models
{
    public class Course
    {
         public int Id { get; set; }


        [DisplayName("Course Name")]
        public string CourseName { get; set; }
    }
}
