using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Services.Common
{
    public static class ControllerExtensions
    {
        public static SelectList GetPager(this Controller controller, int? pageSize)
        {
            return new SelectList(new List<FilterParameter> {
                new FilterParameter { Id = 10, Name = "10"  },
                new FilterParameter { Id = 20, Name = "20" },
                new FilterParameter { Id = 50, Name = "50" },
                new FilterParameter { Id = 100, Name = "100"},
                new FilterParameter { Id = 1000, Name = "1000"},
                new FilterParameter { Id = 0, Name = "All"  },
            }, "Id", "Name", pageSize);
        }
        public class FilterParameter
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
