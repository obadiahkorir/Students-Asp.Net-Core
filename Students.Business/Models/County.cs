using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Students.Business.Models
{
    public class County
    {
        public int Id { get; set; }


        [DisplayName("County Name")]
        public string CountyName { get; set; }
    }
}
