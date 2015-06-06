using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SyntacticSugar;

namespace ValidationSuarMVC.Models
{
    public class Validates
    {
        public static void Init()
        {

            //login
            ValidationSugar.Init(PageKeys.LOGIN_KEY,
               ValidationSugar.CreateOptionItem().Set("userName", true/*是否必填*/, "用户名").AddRegex("[a-z,A-Z].*", "用户名必须以数字开头").AddRegex(".{5,15}", "长度为5-15字符").ToOptionItem(),
               ValidationSugar.CreateOptionItem().Set("password", true, "密码").AddRegex(".{5,15}", "长度为5-15字符").ToOptionItem()
               );
            
            //register
            ValidationSugar.Init(PageKeys.REGISTER_KEY,
               ValidationSugar.CreateOptionItem().Set("userName", true, "用户名").AddRegex("[a-z,A-Z].*", "用户名必须以数字开头").AddRegex(".{5,15}", "长度为5-15字符").ToOptionItem(),
               ValidationSugar.CreateOptionItem().Set("password", true, "密码").AddRegex(".{5,15}", "长度为5-15字符").ToOptionItem(),
               ValidationSugar.CreateOptionItem().Set("email", true, "邮箱").Add(ValidationSugar.OptionItemType.Mail, "邮箱格式不正确").ToOptionItem(),
               ValidationSugar.CreateOptionItem().Set("mobile", true, "手机").Add(ValidationSugar.OptionItemType.Mobile,"手机格式不正确").ToOptionItem(),
               ValidationSugar.CreateOptionItem().Set("qq", false, "qq").AddRegex(@"\d{4,15}", "qq号码格式不正确").ToOptionItem()
               
               );
        }
    }
}