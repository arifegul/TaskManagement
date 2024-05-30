using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskManagement.Infrastructure.Shared
{
	public class ResponseInfra<T>
	{
        public T? Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        [JsonIgnore]
        public bool IsSuccessful { get; set; }

        public List<string>? Errors { get; set; }

        public static ResponseInfra<T> Success(T data, int statusCode)
        {
            return new ResponseInfra<T>
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccessful = true,
            };
        }

        public static ResponseInfra<T> Success(int statusCode)
        {
            return new ResponseInfra<T>
            {
                Data = default,
                StatusCode = statusCode,
                IsSuccessful = true,
            };
        }

        public static ResponseInfra<T> Fail(List<string> errors, int statusCode)
        {
            return new ResponseInfra<T>
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSuccessful = false,
            };
        }

        public static ResponseInfra<T> Fail(string error, int statusCode)
        {
            return new ResponseInfra<T>
            {
                Errors = [

                    error
                ],
                StatusCode = statusCode,
                IsSuccessful = false,
            };
        }
    }
}
