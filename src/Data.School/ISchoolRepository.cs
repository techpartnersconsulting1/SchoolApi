using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.School
{
    public interface ISchoolRepository
    {
        SchoolAsOneStringList GetSchoolsByState(SearchDto state);
        SchoolDistrictAsOneStringList GetSchoolDistrictByState(SearchSchoolDistrictDto state);
        GradeDtoList GetGrades();
        GradeDtoList GetSchoolGrades(string schoolId);
        ClassDtoList GetClassesBySchool(string schoolId);
        ClassDtoList GetClassesByGrade(string schoolId, string gradeId);
        StateListDto GetStates();
        SchoolDto GetSchool(string schoolId);
        TeacherListDto GetTeachersInSchool(string schoolId);
        string SaveClass(ClassDtoList school, string schoolId, string gradeId);
        string SaveSchool(SchoolDto dto);
        string SaveTeacherToSchool(TeacherDto dto, string schoolId);
    }
}
