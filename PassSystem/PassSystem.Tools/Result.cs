using System;
using System.Collections.Generic;
using System.Linq;

namespace PassSystem.Tools
{
    public class Result<T>
    {
        private List<String> _errors;
        public T Data { get; set; }
        public List<String> Errors { get; set; }

        public Boolean IsSuccess => !Errors?.Any() ?? true;
        public Boolean IsFailed => Errors?.Any() ?? false;

        public static Result<T> Success(T data)
        {
            return new Result<T>()
            {
                Data = data
            };
        }
        
        public static Result<T> Failed(String error)
        {
            return new Result<T>()
            {
                Errors = new List<string>(){error}
            };
        }
        
        public static Result<T> Failed(IEnumerable<String> errors)
        {
            return new Result<T>()
            {
                Errors = errors.ToList()
            };
        }
        
        

    }
}