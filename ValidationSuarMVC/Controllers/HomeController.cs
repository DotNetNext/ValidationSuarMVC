using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SyntacticSugar;
using ValidationSuarMVC.Models;

namespace ValidationSuarMVC.Controllers
{
    public class HomeController : Controller
    {
        private string _pageKey = "index";

        public ActionResult Index()
        {
            ViewBag.validationBind = ValidationSugar.GetInitScript(_pageKey, new List<ValidationSugar.OptionItem>()
                {
                    new ValidationSugar.OptionItem(){  Type=ValidationSugar.OptionItemType.Mail, IsRequired=false, Placeholder="邮箱", Tip="格式为:xx@xx.xx", FormFiledName="email"},
                    new ValidationSugar.OptionItem(){  Type=ValidationSugar.OptionItemType.Regex, Pattern="^.{5,10}$", IsRequired=true, Placeholder="姓名", Tip="5-10个字符", FormFiledName="name"},
                    new ValidationSugar.OptionItem(){  Type=ValidationSugar.OptionItemType.Regex, Pattern="^0|1$", IsRequired=true, Placeholder="姓别", Tip="请选择姓别", FormFiledName="sex"},
                    new ValidationSugar.OptionItem(){  Type=ValidationSugar.OptionItemType.Regex, Pattern=@"^\d$", IsRequired=true, Placeholder="爱好", Tip="请选择爱好", FormFiledName="hobbies",IsMultiselect=true /*多选一定要加将这属性设为true*/}
                         
                });
            return View();
        }

        [HttpPost]
        public JsonResult Post()
        {
            string message = string.Empty;
            var isValid = ValidationSugar.PostValidation(_pageKey, out message);
            var model = new JsonResultModel<ValidationSugar>() { };
            if (isValid)
            {
                //执行后台逻辑...
                model.Code = 1;
                model.Message = "验证通过";
            }
            else {
                model.Code = -1;
                model.Message = "参数不合法";
                model.Json = message;
            
            }
            return Json(model);
        }

    }
}
