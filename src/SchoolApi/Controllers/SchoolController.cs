using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Api.School.Model;

namespace School.Api.School.Controllers
{
    [Route("v1/[controller]")]
    [Produces("application/json")]
    public class SchoolsController : Controller
    {
  
        
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
    


        // GET api/values
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
                SchoolDto  sch = new Model.SchoolDto();
                sch.Address = "5, Kory Drive";
                sch.City = "Kendall Park";
                sch.ID = "2501";
                sch.IsActive = "Active";
                sch.Name = "BrunswickAcres school";
                sch.SchoolDistrictId = "1001";
                sch.State = "NJ";
                sch.GradeIds = new List<string> { "1", "2", "3", "4", "5", "6" };
             
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




       

        // GET api/values
        [HttpGet]
        [Route("Grades/{gradeId}/Classes")]
        public IActionResult Search(string  gradeId)
        {
           
            
            ObjectResult result = null;
            try
            {
                Response<ClasssDtoList> resp = new Response<ClasssDtoList>();

                ClasssDtoList list = new Model.ClasssDtoList();
                list.Classes.Add(new ClassDto { Id = "10", Name = "Mrs Amoia" });
                list.Classes.Add(new ClassDto { Id = "12", Name = "Ms Thoten" });
                list.Classes.Add(new ClassDto { Id = "13", Name = "Ms McKenzie" });
                list.Classes.Add(new ClassDto { Id = "14", Name = "Mr Battaaeo" });
                list.Classes.Add(new ClassDto { Id = "25", Name = "Mrs Stemmler" });
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
        

        // GET api/values
        [HttpPost]
        [Route("Grade/{gradeId}/Class")]
        public IActionResult SaveClass([FromBody] ClassSaveRequest request,string gradeId )
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
       

        // GET api/values
        [HttpGet]
        [Route("{schoolId}/Teachers")]
        public IActionResult GetTeachersInSchool( string schoolId)
        {
            
            ObjectResult result = null;
            try
            {
                Response<TeacherListDto> resp  = new Response<TeacherListDto>();
                TeacherListDto list = new Model.TeacherListDto();
                list.Teachers.Add(new TeacherDto { Id = "1009", Name = "Mrs Amoia" });
                list.Teachers.Add(new TeacherDto {Id = "1001",Name = "Mrs Stemmler"});
                list.Teachers.Add(new TeacherDto { Id = "1002", Name = "Mrs Smart" });
                list.Teachers.Add(new TeacherDto { Id = "1003", Name = "Mr Edwards" });
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
                StateList list = new Model.StateList();
                list.States.Add(new StateDto {StateCd  = "NJ", StateName = "New Jersey" });
                list.States.Add(new StateDto { StateCd = "PA", StateName = "Pennsylvania" });
                list.States.Add(new StateDto { StateCd = "CT", StateName = "Connecticut" });
                list.States.Add(new StateDto { StateCd = "MA", StateName = "Massachuesettes" });
                list.States.Add(new StateDto { StateCd = "CA", StateName = "California" });

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

        // GET api/values
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
