using System.Collections.Generic;
using Newtonsoft.Json;

namespace Data.School
{
    public class ClassDtoList
    {
        [JsonProperty("classes")]
        public List<ClassDto> Classes = new List<ClassDto>();
    }
}