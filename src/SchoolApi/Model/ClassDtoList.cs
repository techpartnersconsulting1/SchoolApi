using System.Collections.Generic;
using Newtonsoft.Json;

namespace School.Api.School.Model
{
    public class ClassDtoList
    {
        [JsonProperty("classes")]
        public List<ClassDto> Classes = new List<ClassDto>();
    }
}