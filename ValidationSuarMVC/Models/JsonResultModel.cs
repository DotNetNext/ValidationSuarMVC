using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValidationSuarMVC.Models
{
    /// <summary>
    /// 异步返回类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AsyncResultModel<T> where T:new()
    {
        public int Code { get; set; }
        public T Model { get; set; }
        public string Message { get; set; }
        public string Json { get; set; }
    }
}