using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Api.School.Model
{
    public class SaveRequestDto
    {
        public SchoolDto School { get; set; } = new SchoolDto();
    }
}
