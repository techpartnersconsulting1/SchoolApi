using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School.Api.School.Model;

namespace School.Api.School.Data
{
    public interface ISchoolRepository
    {

        //void Add(ClsRoom item);
        // IEnumerable<EventProgramRelations> GetAll();
       // IEnumerable<ClsRoom> SearchSchoolDistrict(SearchSchoolDistrictRequest ID);
        //void Remove(ClsRoom item);
       // void Update(ClsRoom item);
        SchoolDto GetSchoolByState(SearchSchoolDistrictDto state);
        SearchSchoolDistrictDto GetSchoolDistrictByState(SearchSchoolDistrictDto state);
        GradeDtoList GetGrades(string schoolId);
        GradeDtoList GetSchoolGrades(string schoolId);
        ClasssDtoList GetClassesBySchool(string schoolId);
        ClasssDtoList GetClassesByGrade(string schoolGradeId);
        StateList GetStates();
        SchoolDto GetSchool(string schoolId);
        TeacherListDto GetTeachersInSchool(string schoolId);
    }
}
