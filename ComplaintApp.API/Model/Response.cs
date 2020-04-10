using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ComplaintApp.API.Model
{
    public static class Response
    {
        public static DataTransfer<T> GetSuccessResponse<T>(T data, string message = null, string token = null)
        {
            DataTransfer<T> dataTransfer = new DataTransfer<T>
            {
                StatusCode = HttpStatusCode.OK,
                Data = data,
                Token = token,
                Message = message
            };
            return dataTransfer;
        }
        public static DataTransfer<T> GetNotFoundResponse<T>(T data, string message = null)
        {
            DataTransfer<T> dataTransfer = new DataTransfer<T>
            {
                StatusCode = HttpStatusCode.NotFound,
                Data = data,
                Message = message
            };
            return dataTransfer;
        }
        public static DataTransfer<T> GetValidateResponse<T>(T data, string message = null)
        {
            DataTransfer<T> dataTransfer = new DataTransfer<T>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Data = data,
                Message = message
            };
            return dataTransfer;
        }

        public static DataTransfer<T> GetFailedResponse<T>(T data, string message = null)
        {
            // TODO : Database Exception Logging
            //errorModel.Exceptions;
            //errorModel.Method;
            //errorModel.Service;

            DataTransfer<T> dataTransfer = new DataTransfer<T>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = message,
                Data = default(T)
            };
            return dataTransfer;
        }
    }

    public class DataTransfer<T>
    {
        public string Message { get; set; }
        public string Token { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }
    }
}
