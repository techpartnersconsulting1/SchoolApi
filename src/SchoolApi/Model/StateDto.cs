using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Api.School.Model
{
    public class StateDto
    {

        public string StateCd { get; set; } = string.Empty;
        public string StateName { get; set; } = string.Empty;


    }

    public class StateList
    {

        public List<StateDto> States { get; set; } = new List<StateDto>();



    }
}
