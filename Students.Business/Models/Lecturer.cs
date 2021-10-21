using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Students.Business.Models
{
    public class Lecturer
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Gender")]
        public int? GenderId { get; set; }

        public SystemCodeDetail Gender { get; set; }

        [DisplayName("Ethnicity")]
        public int? EthnicityId { get; set; }
        public SystemCodeDetail Ethnicity { get; set; }

        [DisplayName("County")]
        public int? CountyId { get; set; }
        public SystemCodeDetail County { get; set; }

        [DisplayName("Country")]
        public int? CountryId { get; set; }

        public SystemCodeDetail Country { get; set; }

        [DisplayName("Educational Level")]
        public int? EducationLevelId { get; set; }

        public SystemCodeDetail EducationLevel { get; set; }

        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }


        [DisplayName("Telephone No")]
        public string TelephoneNo { get; set; }


        [DisplayName("Date of Birth")]
        public DateTime DOB { get; set; }

        [DisplayName("Citizenship")]
        public int? CitizenshipId { get; set; }

        public SystemCodeDetail Citizenship { get; set; }

        [DisplayName("Department Name")]
        public int? DepartmentId { get; set; }
        public SystemCodeDetail Department { get; set; }

        [DisplayName("Course Name")]
        public int? CourseId { get; set; }
        public Course Course { get; set; }
    }
}
