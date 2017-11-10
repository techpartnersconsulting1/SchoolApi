using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using School.Api.School.Model;
using School.Api.School.Services;

namespace School.Api.School.Data
{
    public class SchoolRepository: ISchoolRepository
    {
        private ConfigOptions OptionsConString { get; }

        public SchoolRepository(IOptions<ConfigOptions> optionsAccessor)
        {
            OptionsConString = optionsAccessor.Value;
        }

        public SchoolDto GetSchoolByState(SearchSchoolDistrictDto state)
        {
            string queryString = "[dbo].[sp_AdmSchoolByState]";
            using (SqlConnection connection = new SqlConnection(OptionsConString.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter { ParameterName = "@State", DbType = DbType.String, Value = state.State });
                        command.Parameters.Add(new SqlParameter { ParameterName = "@UserID", DbType = DbType.Int32, Value = Convert.ToInt32(state.userId) });
                        var dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            SchoolDto school = new SchoolDto()
                            {
                                id = dr["SchoolId"].ToString(),
                                name = dr["SchoolName"].ToString(),
                                city = dr["Address"].ToString(),
                                address = dr["City"].ToString(),
                                state = dr["State"].ToString(),
                                //schoolDistrictId = dr["Zip"].ToString()
                            };
                            return school;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            return null;
        }

        public SearchSchoolDistrictDto GetSchoolDistrictByState(SearchSchoolDistrictDto state)
        {
            throw new NotImplementedException();
        }

        public GradeDtoList GetGrades()
        {
            var result = new GradeDtoList();
            string queryString = "[dbo].[sp_AdmMasterGrade]";
            using (SqlConnection connection = new SqlConnection(OptionsConString.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        var dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            var newGrade = new GradeDto();
                            newGrade.SchoolId = dr["SchoolID"].ToString();
                            newGrade.Id = dr["GradeID"].ToString();
                            newGrade.Name = dr["GradeName"].ToString();
                            result.Grades.Add(newGrade);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            return result;
        }

        public GradeDtoList GetSchoolGrades(string schoolId)
        {
            var result = new GradeDtoList();
            string queryString = "[dbo].[sp_AdmGrade]";
            using (SqlConnection connection = new SqlConnection(OptionsConString.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter { ParameterName = "@SchoolID", DbType = DbType.Int32, Value = Convert.ToInt32(schoolId) });
                        var dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            var newGrade = new GradeDto();
                            newGrade.SchoolId = dr["GradeSchoolID"].ToString();
                            newGrade.Id = dr["GradeID"].ToString();
                            newGrade.Name = dr["GradeName"].ToString();
                            result.Grades.Add(newGrade);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            return result;
        }

        public ClasssDtoList GetClassesBySchool(string schoolId)
        {
            var result = new ClasssDtoList();
            
            string queryString = "[dbo].[sp_AdmClassbySchool]";
            using (SqlConnection connection = new SqlConnection(OptionsConString.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter { ParameterName = "@SchoolID", DbType = DbType.Int32, Value = Convert.ToInt32(schoolId) });
                        var jsonString = command.ExecuteScalar() as string;
                        var jsonArr = JArray.Parse(jsonString);
                        if (jsonArr == null || jsonArr.Count == 0) return null;
                        var jobj = jsonArr[0]?["dto"]?["classes"];
                        var obj = jobj?.ToObject<List<ClassDto>>();
                        result.Classes = obj;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            return result;
        }

        public TeacherListDto GetTeachersInSchool(string schoolId)
        {
            var result = new TeacherListDto();

            string queryString = "[dbo].[sp_AdmTeacherbySchool]";
            using (SqlConnection connection = new SqlConnection(OptionsConString.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter { ParameterName = "@SchoolID", DbType = DbType.Int32, Value = Convert.ToInt32(schoolId) });
                        var dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            // TODO: CONFIRM  IT
                            var newTeacher = new TeacherDto();
                            newTeacher.Id = dr["UserID"].ToString();
                            newTeacher.Name = dr["FirstName"].ToString();
                            newTeacher.Name = dr["LastName"].ToString();
                            //newTeacher.Active = dr["Active"].ToString();
                            result.Teachers.Add(newTeacher);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            return result;
        }

        public ClasssDtoList GetClassesByGrade(string schoolGradeId)
        {
            var result = new ClasssDtoList();

            string queryString = "[dbo].[sp_AdmClassByGrade]";
            using (SqlConnection connection = new SqlConnection(OptionsConString.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter { ParameterName = "@GradeSchoolID", DbType = DbType.Int32, Value = Convert.ToInt32(schoolGradeId) });
                        var jsonString = command.ExecuteScalar() as string;
                        var jsonArr = JArray.Parse(jsonString);
                        if (jsonArr == null || jsonArr.Count == 0) return null;
                        var jobj = jsonArr[0]?["dto"]?["classes"];
                        var obj = jobj?.ToObject<List<ClassDto>>();
                        result.Classes = obj;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            return result;
        }

        public StateList GetStates()
        {
            var result = new StateList
            {
                States = new List<StateDto>()
                {
                    new StateDto()
                    {
                        StateName = "Alabama",
                        StateCd = "AL"
                    },
                    new StateDto()
                    {
                        StateName = "Alaska",
                        StateCd = "AK"
                    },
                    new StateDto()
                    {
                        StateName = "American Samoa",
                        StateCd = "AS"
                    },
                    new StateDto()
                    {
                        StateName = "Arizona",
                        StateCd = "AZ"
                    },
                    new StateDto()
                    {
                        StateName = "Arkansas",
                        StateCd = "AR"
                    },
                    new StateDto()
                    {
                        StateName = "California",
                        StateCd = "CA"
                    },
                    new StateDto()
                    {
                        StateName = "Colorado",
                        StateCd = "CO"
                    },
                    new StateDto()
                    {
                        StateName = "Connecticut",
                        StateCd = "CT"
                    },
                    new StateDto()
                    {
                        StateName = "Delaware",
                        StateCd = "DE"
                    },
                    new StateDto()
                    {
                        StateName = "District Of Columbia",
                        StateCd = "DC"
                    },
                    new StateDto()
                    {
                        StateName = "Federated States Of Micronesia",
                        StateCd = "FM"
                    },
                    new StateDto()
                    {
                        StateName = "Florida",
                        StateCd = "FL"
                    },
                    new StateDto()
                    {
                        StateName = "Georgia",
                        StateCd = "GA"
                    },
                    new StateDto()
                    {
                        StateName = "Guam",
                        StateCd = "GU"
                    },
                    new StateDto()
                    {
                        StateName = "Hawaii",
                        StateCd = "HI"
                    },
                    new StateDto()
                    {
                        StateName = "Idaho",
                        StateCd = "ID"
                    },
                    new StateDto()
                    {
                        StateName = "Illinois",
                        StateCd = "IL"
                    },
                    new StateDto()
                    {
                        StateName = "Indiana",
                        StateCd = "IN"
                    },
                    new StateDto()
                    {
                        StateName = "Iowa",
                        StateCd = "IA"
                    },
                    new StateDto()
                    {
                        StateName = "Kansas",
                        StateCd = "KS"
                    },
                    new StateDto()
                    {
                        StateName = "Kentucky",
                        StateCd = "KY"
                    },
                    new StateDto()
                    {
                        StateName = "Louisiana",
                        StateCd = "LA"
                    },
                    new StateDto()
                    {
                        StateName = "Maine",
                        StateCd = "ME"
                    },
                    new StateDto()
                    {
                        StateName = "Marshall Islands",
                        StateCd = "MH"
                    },
                    new StateDto()
                    {
                        StateName = "Maryland",
                        StateCd = "MD"
                    },
                    new StateDto()
                    {
                        StateName = "Massachusetts",
                        StateCd = "MA"
                    },
                    new StateDto()
                    {
                        StateName = "Michigan",
                        StateCd = "MI"
                    },
                    new StateDto()
                    {
                        StateName = "Minnesota",
                        StateCd = "MN"
                    },
                    new StateDto()
                    {
                        StateName = "Mississippi",
                        StateCd = "MS"
                    },
                    new StateDto()
                    {
                        StateName = "Missouri",
                        StateCd = "MO"
                    },
                    new StateDto()
                    {
                        StateName = "Montana",
                        StateCd = "MT"
                    },
                    new StateDto()
                    {
                        StateName = "Nebraska",
                        StateCd = "NE"
                    },
                    new StateDto()
                    {
                        StateName = "Nevada",
                        StateCd = "NV"
                    },
                    new StateDto()
                    {
                        StateName = "New Hampshire",
                        StateCd = "NH"
                    },
                    new StateDto()
                    {
                        StateName = "New Jersey",
                        StateCd = "NJ"
                    },
                    new StateDto()
                    {
                        StateName = "New Mexico",
                        StateCd = "NM"
                    },
                    new StateDto()
                    {
                        StateName = "New York",
                        StateCd = "NY"
                    },
                    new StateDto()
                    {
                        StateName = "North Carolina",
                        StateCd = "NC"
                    },
                    new StateDto()
                    {
                        StateName = "North Dakota",
                        StateCd = "ND"
                    },
                    new StateDto()
                    {
                        StateName = "Northern Mariana Islands",
                        StateCd = "MP"
                    },
                    new StateDto()
                    {
                        StateName = "Ohio",
                        StateCd = "OH"
                    },
                    new StateDto()
                    {
                        StateName = "Oklahoma",
                        StateCd = "OK"
                    },
                    new StateDto()
                    {
                        StateName = "Oregon",
                        StateCd = "OR"
                    },
                    new StateDto()
                    {
                        StateName = "Palau",
                        StateCd = "PW"
                    },
                    new StateDto()
                    {
                        StateName = "Pennsylvania",
                        StateCd = "PA"
                    },
                    new StateDto()
                    {
                        StateName = "Puerto Rico",
                        StateCd = "PR"
                    },
                    new StateDto()
                    {
                        StateName = "Rhode Island",
                        StateCd = "RI"
                    },
                    new StateDto()
                    {
                        StateName = "South Carolina",
                        StateCd = "SC"
                    },
                    new StateDto()
                    {
                        StateName = "South Dakota",
                        StateCd = "SD"
                    },
                    new StateDto()
                    {
                        StateName = "Tennessee",
                        StateCd = "TN"
                    },
                    new StateDto()
                    {
                        StateName = "Texas",
                        StateCd = "TX"
                    },
                    new StateDto()
                    {
                        StateName = "Utah",
                        StateCd = "UT"
                    },
                    new StateDto()
                    {
                        StateName = "Vermont",
                        StateCd = "VT"
                    },
                    new StateDto()
                    {
                        StateName = "Virgin Islands",
                        StateCd = "VI"
                    },
                    new StateDto()
                    {
                        StateName = "Virginia",
                        StateCd = "VA"
                    },
                    new StateDto()
                    {
                        StateName = "Washington",
                        StateCd = "WA"
                    },
                    new StateDto()
                    {
                        StateName = "West Virginia",
                        StateCd = "WV"
                    },
                    new StateDto()
                    {
                        StateName = "Wisconsin",
                        StateCd = "WI"
                    },
                    new StateDto()
                    {
                        StateName = "Wyoming",
                        StateCd = "WY"
                    }
                }
            };
            return result;
        }

        public SchoolDto GetSchool(string schoolId)
        {
            string queryString = "[dbo].[sp_AdmSchoolDetails]";
            using (SqlConnection connection = new SqlConnection(OptionsConString.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter { ParameterName = "@SchoolID", DbType = DbType.Int32, Value = Convert.ToInt32(schoolId) });
                        var jsonString = command.ExecuteScalar() as string;
                        var jsonArr = JArray.Parse(jsonString);
                        if (jsonArr == null || jsonArr.Count == 0) return null;
                        var jobj = jsonArr[0]["dto"];
                        var obj = jobj?.ToObject<SchoolDto>();
                        return obj;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
        }
    }
}
