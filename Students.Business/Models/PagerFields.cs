using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Students.Business.Models
{
    public class PagerFields
    {
        [DisplayName("Page")]
        public int? Page { get; set; }
        [DisplayName("Page Size")]
        public int? PageSize { get; set; }
    }
}
