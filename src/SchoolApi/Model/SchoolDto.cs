using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Api.School.Model
{
    public class SchoolDto
    {
        public string ID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string State  { get; set; } = string.Empty;

        public string SchoolDistrictId { get; set; } = string.Empty;

        public List<string> GradeIds = new  List<string>();

        public string IsActive { get; set; } = string.Empty;


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
