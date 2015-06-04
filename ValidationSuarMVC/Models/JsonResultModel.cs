using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValidationSuarMVC.Models
{
    public class JsonResultModel<T> where T:new()
    {
        public int Code { get; set; }
        public T Model { get; set; }
        public string Message { get; set; }
        public string Json { get; set; }
    }
}