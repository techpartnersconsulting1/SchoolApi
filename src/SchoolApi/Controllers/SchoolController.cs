using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.School;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using School.Api.School.Model;
using School.Api.School.Services;

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

        public SchoolsController(IOptions<ConfigOptions> options)
        {
            Repository = new SchoolRepository(options.Value.ConnectionString);
        }

        [HttpPost]
        [Route("SearchSchool")]
        public IActionResult SearchSchools([FromBody]SearchSchoolRequest dto)
        {
            ObjectResult result = null;
            try
            {
                Response<SchoolAsOneStringList> resp = new Response<SchoolAsOneStringList>();
                var list = Repository.GetSchoolsByState(dto.Request);
                resp.Message = "Data retrieved.";
                resp.SetDto(list);
                result = new OkObjectResult(resp);
            }
            catch (Exception ex)
            {
                ExceptionDetails errDt = new ExceptionDetails {Message = ex.StackTrace};
                ErrorResponse errResp = new ErrorResponse();
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
                Response<SchoolDistrictListDto> resp = new Response<SchoolDistrictListDto>();
                var list = Repository.GetSchoolDistrictByState(dto.Request);
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
                var jsonResp = Repository.SaveSchool(req.School);
                var jobj = JObject.Parse(jsonResp);
                var newSch = jobj.ToObject<SchoolDto>();
                resp.SetDto(newSch);
                resp.Message = "School Saved.";
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
                var list = Repository.GetGrades();
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
                Response<ClassDtoList> resp = new Response<ClassDtoList>();
                var list = Repository.GetClassesByGrade(schoolId, gradeId);
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
                Response<ClassDtoList> resp = new Response<ClassDtoList>();
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
                Response<ClassDto> resp = new Response<ClassDto>();
                var jsonResp = Repository.SaveClass(request.Classes, schoolId, gradeId);
                var jobj = JObject.Parse(jsonResp);
                var newCls = jobj.ToObject<ClassDto>();
                resp.SetDto(newCls);
                resp.Message = "Classes saved.";
                result = new OkObjectResult(resp);
            }
            catch (Exception ex)
            {
                ExceptionDetails errDt = new ExceptionDetails {Message = ex.StackTrace};
                ErrorResponse errResp = new ErrorResponse();
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
       
        [HttpPost]
        [Route("{schoolId}/Teacher")]
        public IActionResult SaveTeacherToSchool([FromBody] SaveTeacherRequest req, string schoolId)
        {
            ObjectResult result = null;
            try
            {
                Response<TeacherDto> resp = new Response<TeacherDto>();
                var jsonResp = Repository.SaveTeacherToSchool(req.dto, schoolId);
                var jobj = JObject.Parse(jsonResp);
                var newTeacher = jobj.ToObject<TeacherDto>();
                resp.SetDto(newTeacher);
                resp.Message = "Data saved.";
                result = new OkObjectResult(resp);
            }
            catch (Exception ex)
            {
                ExceptionDetails errDt = new ExceptionDetails {Message = ex.StackTrace};
                ErrorResponse errResp = new ErrorResponse();
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
                Response<StateListDto> resp = new Response<StateListDto>();
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
