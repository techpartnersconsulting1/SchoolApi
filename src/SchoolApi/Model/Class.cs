using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Api.School.Model
{

    public class GradeDto
    {

        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;




    }

    public class GradeDtoList
    {

        public List<GradeDto> Grades = new List<GradeDto>();




    }

    public class ClasssDtoList
    {

       
        public List<ClassDto> Classes = new List<ClassDto>();




    }

    public class ClassSaveRequest
    {

        //public string GradeId{ get; set; } = string.Empty;
        public List<ClassDto> Classes = new List<ClassDto>();




    }

    public class ClassDto
    {
        

        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string IsActive { get; set; } = string.Empty;

        public string TeacherId { get; set; } = string.Empty;

       
    }


 

    public class TeacherDto
    {

        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        
    }


    public class TeacherListDto
    {

        public List<TeacherDto> Teachers = new List<TeacherDto>();
    }


    public class SaveTeacherRequest
    {

        public TeacherDto dto = new TeacherDto();


    }
}
