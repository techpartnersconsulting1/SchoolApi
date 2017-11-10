using System.Collections.Generic;

namespace School.Api.School.Model
{
    public class ClassSaveRequest
    {
        //public string GradeId{ get; set; } = string.Empty;
        public List<ClassDto> Classes = new List<ClassDto>();
    }
}