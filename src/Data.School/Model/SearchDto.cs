using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.School
{
    public class SearchDto
    {
        public string State { get; set; } = string.Empty;
        //public string SchoolId { get; set; } = string.Empty;

        //public string SchoolDistrictId { get; set; } = string.Empty;

        public string userId { get; set; } = string.Empty;
        

    }


    public class SearchSchoolDistrictDto
    {
        public string State { get; set; } = string.Empty;

        public string userId { get; set; } = string.Empty;


    }
}
