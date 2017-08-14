using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Api.School.Model
{
    public class ActiveTypesDtoList
    {
        public List<ActiveTypesDto> ActiveTypes { get; set; } = new List<ActiveTypesDto>();


    }

    public class ActiveTypesDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;


    }

}
