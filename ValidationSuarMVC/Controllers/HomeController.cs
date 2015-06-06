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

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            //请在 Global  applicationStart添加  Validates.Init()
            ViewBag.validationBind = ValidationSugar.GetBindScript(PageKeys.LOGIN_KEY);


            //如果是负载均衡引起静态变量丢失可以写成这样,Global就无需注册
            // ViewBag.validationBind = ValidationSugar.GetBindScript(PageKeys.INDEX_KEY, () => { Validates.Init()});
            return View();
        }

        [HttpPost]
        public JsonResult PostLogin()
        {
            string message = string.Empty;
            //后台验证表单成功返回true
            var isValid = ValidationSugar.PostValidation(PageKeys.LOGIN_KEY, out message);

            var model = new AsyncResultModel<ValidationSugar>();
            if (isValid)
            {
                //执行后台逻辑...
                model.Code = 1;
                model.Message = "验证通过";
            }
            else//失败
            {
                model.Code = -1;
                model.Message = "参数不合法";
                model.Json = message;

            }
            return Json(model);
        }


        public ActionResult Register() {
            return View();
        }

    }
}
