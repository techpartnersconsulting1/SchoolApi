using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Api.School.Model
{
    public class Response<T>
    {
       

        public Response()
        {
           
        }

        public string Message { get; set; } = string.Empty;

        public  T Dto { get; set; } = default(T);

     

        public void SetDto( T dto )
        {

            Dto = dto;

        }

   
    }

    public class ErrorResponse
    {


        public ErrorResponse()
        {

        }


        private ExceptionDetails ErrorDetails { get; set; } = default(ExceptionDetails);


        public void SetException(ExceptionDetails exDet)
        {

            ErrorDetails = exDet;

        }
    }
}
