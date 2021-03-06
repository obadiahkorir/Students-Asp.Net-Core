
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using X.PagedList;

namespace Students.Business.Models
{
    public class StudentsModel
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Other Name")]
        public string OtherName { get; set; }

        [DisplayName("Student Name")]
        public string FullName => $"{FirstName} {MiddleName} {LastName}";

        [DisplayName("Ethnicity")]
        public int EthnicityId { get; set; }

        [DisplayName("County")]
        public int CountyId { get; set; }
        public County County { get; set; }
        [DisplayName("Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DOB { get; set; }

        [DisplayName("Course")]

        public int CourseId { get; set; }
        public Course Course { get; set; }

        [DisplayName("Telephone No")]
        public int TelephoneNo { get; set; }

        [DisplayName("Id No")]
        public int IdNumber { get; set; }
    }
}
