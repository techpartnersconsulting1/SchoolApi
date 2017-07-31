using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Api.School.Model
{
    public class SearchSchoolRequest
    {
        public SearchDto Request { get; set; } = new SearchDto();
    }

    public class SearchSchoolDistrictRequest
    {
        public SearchSchoolDistrictDto Request { get; set; } = new SearchSchoolDistrictDto();
    }
    

}
