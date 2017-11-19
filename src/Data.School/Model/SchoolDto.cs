using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.School
{
    public class SchoolDto
    {
        public string id { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;

        public string city { get; set; } = string.Empty;

        public string address { get; set; } = string.Empty;

        public string state  { get; set; } = string.Empty;

        public string schoolDistrictId { get; set; } = string.Empty;

        public List<Grade> gradeIds = new  List<Grade>();

        public string isActive { get; set; } = string.Empty;


    }

    public class Grade
    {
        public string GradeID { get; set; }
    }

    public class SchoolAsOneString
    {

        public string ID { get; set; } = string.Empty;
        public string DataString { get; set; } = string.Empty;

    }

    public class SchoolAsOneStringList
    {

        public List<SchoolAsOneString> Schools = new List<SchoolAsOneString>();

    }

    public class SchoolDistrictAsOneStringList
    {

        public List<SchoolDistrictAsOneString> SchoolDistricts = new List<SchoolDistrictAsOneString>();

    }

    public class SchoolDistrictAsOneString
    {

        public string ID { get; set; } = string.Empty;
        public string DataString { get; set; } = string.Empty;

    }
}
