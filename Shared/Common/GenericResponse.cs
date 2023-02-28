using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTHApplication.Shared.Common
{
    public class GenericResponse
    {
        public GenericResponse()
        {

        }

        public GenericResponse(int code, string message, bool isSuccess)
        {
            Code = code;
            Message = message;
            IsSuccess = isSuccess;
        }
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }

        public static GenericResponse Success(string message)
        {
            return new GenericResponse()
            {
                Code = 200,
                IsSuccess = true,
                Message = message
            };
        }

        public static GenericResponse Failed(string message)
        {
            return new GenericResponse()
            {
                Code = 500,
                IsSuccess = false,
                Message = message
            };
        }
    }
    public class GenericResponse<T>
    {
        public GenericResponse()
        {
        }
        public GenericResponse(int code, string message, T? result, bool isSuccess)
        {
            Code = code;
            Message = message;
            Result = result;
            IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; set; }
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Result { get; set; }
    }

    public class GenericListResponse<T>
    {
        public GenericListResponse()
        {

        }
        public GenericListResponse(int code, string message, List<T>? results, bool isSuccess)
        {
            Code = code;
            Message = message;
            Results = results;
            IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; set; }
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<T>? Results { get; set; }
    }
}
