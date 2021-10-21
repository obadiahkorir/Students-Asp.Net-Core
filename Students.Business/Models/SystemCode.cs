using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Students.Business.Models
{
   public class SystemCode
    {
        public int Id { get; set; }

        public string Code { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<SystemCodeDetail> SystemCodeDetails { get; set; }
    }
}
