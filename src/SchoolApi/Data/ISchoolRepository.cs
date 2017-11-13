using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School.Api.School.Model;

namespace School.Api.School.Data
{
    public interface ISchoolRepository
    {
        SchoolAsOneStringList GetSchoolsByState(SearchDto state);
        SchoolDistrictListDto GetSchoolDistrictByState(SearchSchoolDistrictDto state);
        GradeDtoList GetGrades();
        GradeDtoList GetSchoolGrades(string schoolId);
        ClassDtoList GetClassesBySchool(string schoolId);
        ClassDtoList GetClassesByGrade(string schoolGradeId);
        StateListDto GetStates();
        SchoolDto GetSchool(string schoolId);
        TeacherListDto GetTeachersInSchool(string schoolId);
        string SaveClass(ClassDtoList school, string schoolId, string gradeId);
        string SaveSchool(SchoolDto dto);
    }
}
