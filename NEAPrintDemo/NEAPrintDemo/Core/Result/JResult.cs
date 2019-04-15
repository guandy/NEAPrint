using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEAPrintDemo
{
    public class JResult
    {

        public static CommonResult Success()
        {
            return new CommonResult()
            {
                Result = true,
                Message = "success",
                Code = "0"
            };
        }

        public static CommonResult Success(string msg, string code)
        {
            return new CommonResult()
            {
                Result = true,
                Message = msg,
                Code = code
            };
        }

        public static CommonResult Success(string msg, string code, object data)
        {
            return new CommonResult()
            {
                Result = true,
                Message = msg,
                Code = code,
                Data = data
            };
        }

        public static CommonResult Success(string msg)
        {
            return new CommonResult()
            {
                Result = true,
                Message = msg,
                Code = "0",
            };
        }



        public static CommonResult Success(string msg, object data)
        {
            return new CommonResult()
            {
                Result = true,
                Message = msg,
                Code = "0",
                Data = data,
            };
        }

        public static CommonResult Success<T>(string msg, List<T> data)
        {
            return new CommonResult()
            {
                Result = true,
                Message = msg,
                Code = "0",
                Data = data,
                Total = data.Count
            };
        }

        public static CommonResult Success(object data)
        {
            return new CommonResult()
            {
                Result = true,
                Message = "success",
                Code = "0",
                Data = data
            };
        }

        public static CommonResult Error()
        {
            return new CommonResult()
            {
                Result = false,
                Message = "error",
                Code = "-1",
            };
        }

        public static CommonResult Error(string msg)
        {
            return new CommonResult()
            {
                Result = false,
                Message = msg,
                Code = "-1",
            };
        }

        public static CommonResult Error(string msg, string code)
        {
            return new CommonResult()
            {
                Result = false,
                Message = msg,
                Code = code
            };
        }

        public static CommonResult Error(string msg, string code, object data)
        {
            return new CommonResult()
            {
                Result = false,
                Message = msg,
                Code = code,
                Data = data
            };
        }

        public static CommonResult ErrorMsg(string msg, string code)
        {
            return new CommonResult()
            {
                Result = false,
                Message = msg,
                Code = code
            };
        }

    }
}
