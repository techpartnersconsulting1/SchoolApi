using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using School.Api.School.Data;
using School.Api.School.Model;

namespace School.Api.School.Controllers
{
    [Route("v1/[controller]")]
    [Produces("application/json")]
    public class SchoolsController : Controller
    {
        private ISchoolRepository Repository
        {
            get;
        }

        public SchoolsController(ISchoolRepository repository)
        {
            this.Repository = repository;
        }

        [HttpPost]
        [Route("SearchSchool")]
        public IActionResult SearchSchools([FromBody]SearchSchoolRequest dto)
        {

            ObjectResult result = null;
            try
            {
                Response<SchoolAsOneStringList> resp = new Response<SchoolAsOneStringList>();
                SchoolAsOneStringList list = new SchoolAsOneStringList();
                list.Schools.Add(new SchoolAsOneString { ID = "201",DataString =  "Brunswick Acres Elementary,12 Kory Lane, Kendall Park,NJ,08824" });
                list.Schools.Add(new SchoolAsOneString { ID = "202", DataString = "Cambridge elementary School,234 Stouts Lane, Kendall Park,NJ,08824" });
                resp.Message = "Data retrieved.";
                resp.SetDto(list);
                result = new OkObjectResult(resp);
            }
            catch (Exception ex)
            {
                ErrorResponse errResp = new ErrorResponse();
                ExceptionDetails errDt = new ExceptionDetails();
                errDt.Message = ex.StackTrace;
                errResp.SetException(errDt);
                result = StatusCode(500, errResp);

            }
            return result;

        }
    


        [HttpPost]
        [Route("SearchSchoolDistrict")]
        public IActionResult SearchSchoolDistrict([FromBody]SearchSchoolDistrictRequest dto)
        {

            ObjectResult result = null;
            try
            {
                Response<SchoolDistrictAsOneStringList> resp = new Response<SchoolDistrictAsOneStringList>();
                SchoolDistrictAsOneStringList list = new SchoolDistrictAsOneStringList();
                list.SchoolDistricts.Add(new SchoolDistrictAsOneString { ID = "101", DataString = "South Brunswick School district,12 Kory Lane, South Brunswick,NJ,08824" });
                list.SchoolDistricts.Add(new SchoolDistrictAsOneString { ID = "102", DataString = "Franklin Park  School District,234 Stouts Lane, Somerset Park,NJ,08826" });
                resp.SetDto(list);
                resp.Message = "Data retrieved.";
                result = new OkObjectResult(resp);
            }
            catch (Exception ex)
            {
                ErrorResponse errResp = new ErrorResponse();
                ExceptionDetails errDt = new ExceptionDetails();
                errDt.Message = ex.StackTrace;
                errResp.SetException(errDt);
                result = StatusCode(500, errResp);

            }
            return result;

        }


        [HttpGet]
        [Route("{schoolId}")]
        public IActionResult GetSchool(string schoolId)
        {

            ObjectResult result = null;
            try
            {
                Response<SchoolDto> resp = new Response<SchoolDto>();
                var schoolDto = Repository.GetSchool(schoolId);
                resp.SetDto(schoolDto);
                if (schoolDto != null)
                {
                    resp.Message = "Data retrieved.";
                    result = new OkObjectResult(resp);
                }
                else
                {
                    result = new BadRequestObjectResult(resp);
                }
                
            }
            catch (Exception ex)
            {
                ErrorResponse errResp = new ErrorResponse();
                ExceptionDetails errDt = new ExceptionDetails();
                errDt.Message = ex.StackTrace;
                errResp.SetException(errDt);
                result = StatusCode(500, errResp);
            }
            return result;

        }

        [HttpPost]
        [Route("Save")]
        public IActionResult SaveSchool([FromBody] SaveRequestDto req)
        {

            ObjectResult result = null;
            try
            {
                Response<SchoolDto> resp = new Response<SchoolDto>();
                SchoolDto sch = new Model.SchoolDto();
                sch.Address = req.School.Address;
                sch.City = req.School.City;
                sch.ID = "2501";
                sch.IsActive = req.School.IsActive;
                sch.Name = req.School.Name;
                sch.SchoolDistrictId = req.School.SchoolDistrictId;
                sch.State = req.School.State;
                sch.GradeIds = req.School.GradeIds;

                resp.SetDto(sch);
                resp.Message = "Data retrieved.";
                result = new OkObjectResult(resp);
            }
            catch (Exception ex)
            {
                ErrorResponse errResp = new ErrorResponse();
                ExceptionDetails errDt = new ExceptionDetails();
                errDt.Message = ex.StackTrace;
                errResp.SetException(errDt);
                result = StatusCode(500, errResp);

            }
            return result;

        }




        [HttpGet]
        [Route("Grades")]
        public IActionResult Grades( )
        {

            ObjectResult result = null;
            try
            {
                Response<GradeDtoList> resp = new Response<GradeDtoList>();
                GradeDtoList list = new Model.GradeDtoList();
                list.Grades.Add(new GradeDto { Id = "1", Name = "Pre-K" });
                list.Grades.Add(new GradeDto { Id = "2", Name = "KG" });
                list.Grades.Add(new GradeDto { Id = "3", Name = "First" });
                list.Grades.Add(new GradeDto { Id = "4", Name = "Second" });
                list.Grades.Add(new GradeDto { Id = "5", Name = "Third" });
                list.Grades.Add(new GradeDto { Id = "6", Name = "Forth" });
                list.Grades.Add(new GradeDto { Id = "7", Name = "Fifth" });
                list.Grades.Add(new GradeDto { Id = "8", Name = "Sixth" });
                resp.SetDto(list);
                resp.Message = "Data retrieved.";
                result = new OkObjectResult(resp);
            }
            catch (Exception ex)
            {
                ErrorResponse errResp = new ErrorResponse();
                ExceptionDetails errDt = new ExceptionDetails();
                errDt.Message = ex.StackTrace;
                errResp.SetException(errDt);
                result = StatusCode(500, errResp);

            }
            return result;

        }



        [HttpGet]
        [Route("{schoolId}/Grades")]
        public IActionResult Grades(string schoolId)
        {
            
            ObjectResult result = null;
            try
            {
                Response<GradeDtoList> resp = new Response<GradeDtoList>();
                var list = Repository.GetSchoolGrades(schoolId);
                resp.SetDto(list);
                resp.Message = "Data retrieved.";
                result = new OkObjectResult(resp);
            }
            catch (Exception ex)
            {
                ErrorResponse errResp = new ErrorResponse();
                ExceptionDetails errDt = new ExceptionDetails();
                errDt.Message = ex.StackTrace;
                errResp.SetException(errDt);
                result = StatusCode(500, errResp);
            }
            return result;
        }




       

        [HttpGet]
        [Route("{schoolId}/Grades/{gradeId}/Classes")]
        public IActionResult Search(string schoolId,string  gradeId)
        {
            ObjectResult result = null;
            try
            {
                Response<ClasssDtoList> resp = new Response<ClasssDtoList>();
                // TODO: IMPORTANT!!! How to convert "schoolId" + "gradeId" into @SchoolGradeID
                var list = Repository.GetClassesByGrade(gradeId);
                resp.SetDto(list);
                resp.Message = "Data retrieved";

                result =  new OkObjectResult(resp);
            }
            catch (Exception ex)
            {
                ErrorResponse errResp = new ErrorResponse();
                ExceptionDetails errDt = new ExceptionDetails();
                errDt.Message = ex.StackTrace;
                errResp.SetException(errDt);
                result = StatusCode(500, errResp);

            }
            return result;
        }



        [HttpGet]
        [Route("{schoolId}/Classes")]
        public IActionResult SearchClassBySchoolId(string schoolId)
        {


            ObjectResult result = null;
            try
            {
                Response<ClasssDtoList> resp = new Response<ClasssDtoList>();
                var list = Repository.GetClassesBySchool(schoolId);
                resp.SetDto(list);
                resp.Message = "Data retrieved";
                result = new OkObjectResult(resp);
            }
            catch (Exception ex)
            {
                ErrorResponse errResp = new ErrorResponse();
                ExceptionDetails errDt = new ExceptionDetails();
                errDt.Message = ex.StackTrace;
                errResp.SetException(errDt);
                result = StatusCode(500, errResp);

            }
            return result;

        }



        [HttpPost]
        [Route("{schoolId}/Grade/{gradeId}/Class")]
        public IActionResult SaveClass([FromBody] ClassSaveRequest request, string schoolId, string gradeId )
        {
            ObjectResult result = null;
            try
            {
                Response<ClasssDtoList> resp = new Response<ClasssDtoList>();
                ClasssDtoList list = new Model.ClasssDtoList();
                list.Classes.Add(new ClassDto { Id = "10", Name =request.Classes[0].Name ,IsActive =request.Classes[0].IsActive,TeacherId = request.Classes[0].TeacherId });
               
                resp.SetDto(list);
                resp.Message = "Classes saved";
                result = new OkObjectResult(resp);
            }
            catch (Exception ex)
            {
                ErrorResponse errResp = new ErrorResponse();
                ExceptionDetails errDt = new ExceptionDetails();
                errDt.Message = ex.StackTrace;
                errResp.SetException(errDt);
                result = StatusCode(500, errResp);

            }
            return result;

        }
       

        [HttpGet]
        [Route("{schoolId}/Teachers")]
        public IActionResult GetTeachersInSchool(string schoolId)
        {
            
            ObjectResult result = null;
            try
            {
                Response<TeacherListDto> resp  = new Response<TeacherListDto>();
                var list = Repository.GetTeachersInSchool(schoolId);
                resp.Message = "Data retrieved";
                resp.SetDto(list);
                result = new OkObjectResult(resp);
            }
            catch (Exception ex)
            {
                ErrorResponse errResp = new ErrorResponse();
                ExceptionDetails errDt = new ExceptionDetails();
                errDt.Message = ex.StackTrace;
                errResp.SetException(errDt);
                result = StatusCode(500, errResp);

            }
            return result;

        }
       
        // GET api/values
        [HttpPost]
        [Route("{schoolId}/Teacher")]
        public IActionResult SaveTeacherToSchool([FromBody] SaveTeacherRequest req, string schoolId)
        {

            ObjectResult result = null;
            try
            {
                Response<TeacherDto> resp = new Response<TeacherDto>();
                TeacherDto dto = new Model.TeacherDto();
                dto.Id = "12345";
                dto.Name = req.dto.Name;
                resp.Message = "Data saved.";
                resp.SetDto(dto);
                result = new OkObjectResult(resp);
            }
            catch (Exception ex)
            {
                ErrorResponse errResp = new ErrorResponse();
                ExceptionDetails errDt = new ExceptionDetails();
                errDt.Message = ex.StackTrace;
                errResp.SetException(errDt);
                result = StatusCode(500, errResp);

            }
            return result;

        }






        [HttpGet]
        [Route("States")]
        public IActionResult States()
        {
            ObjectResult result = null;
            try
            {
                Response<StateList> resp = new Response<StateList>();
                var list = Repository.GetStates();
                resp.SetDto(list);
                resp.Message = "Data retrieved.";
                result = new OkObjectResult(resp);
            }
            catch (Exception ex)
            {
                ErrorResponse errResp = new ErrorResponse();
                ExceptionDetails errDt = new ExceptionDetails();
                errDt.Message = ex.StackTrace;
                errResp.SetException(errDt);
                result = StatusCode(500, errResp);
            }
            return result;

        }

        [HttpGet]
        [Route("ActiveTypes")]
        public IActionResult ActiveTypes()
        {
            ObjectResult result = null;
            try
            {
                Response<ActiveTypesDtoList> resp = new Response<ActiveTypesDtoList>();
                ActiveTypesDtoList list = new ActiveTypesDtoList();
                list.ActiveTypes.Add(new ActiveTypesDto { Name = "Active", Id = "Active" });
                list.ActiveTypes.Add(new ActiveTypesDto { Name = "InActive", Id = "InActive" });

                resp.SetDto(list);
                resp.Message = "Data retrieved.";
                result = new OkObjectResult(resp);
            }
            catch (Exception ex)
            {
                ErrorResponse errResp = new ErrorResponse();
                ExceptionDetails errDt = new ExceptionDetails();
                errDt.Message = ex.StackTrace;
                errResp.SetException(errDt);
                result = StatusCode(500, errResp);
            }

            return result;
        }


    }
}
