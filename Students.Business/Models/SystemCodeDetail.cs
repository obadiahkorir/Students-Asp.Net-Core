using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Students.Business.Models
{
    public class SystemCodeDetail
    {
        public int Id { get; set; }

        [DisplayName("Parent")]
        public int SystemCodeId { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        [DisplayName("Order No.")]
        public int? OrderNo { get; set; }
        public SystemCode SystemCode { get; set; }
    }
}
