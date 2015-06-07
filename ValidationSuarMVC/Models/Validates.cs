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
               ValidationSugar.CreateOptionItem().Set("userName", true/*是否必填*/, "用户名").AddRegex("[a-z,A-Z].*", "用户名必须以字母开头").AddRegex(".{5,15}", "长度为5-15字符").AddFunc("checkUserName", "用户名不存在，输入 admin1 试试").ToOptionItem(),
               ValidationSugar.CreateOptionItem().Set("password", true, "密码").AddRegex("[0-9].*", "用户名必须以数字开头").AddRegex(".{5,15}", "长度为5-15字符").ToOptionItem()
               );

            //register
            ValidationSugar.Init(PageKeys.REGISTER_KEY,
               ValidationSugar.CreateOptionItem().Set("userName", true, "用户名").AddRegex("[a-z,A-Z].*", "用户名必须以字母开头").AddRegex(".{5,15}", "长度为5-15字符").AddFunc("checkUserName", "用户名已存在!").ToOptionItem(),
               ValidationSugar.CreateOptionItem().Set("password", true, "密码").AddRegex(".{5,15}", "长度为5-15字符").ToOptionItem(),
               ValidationSugar.CreateOptionItem().Set("password2", true, "密码").AddRegex(".{5,15}", "长度为5-15字符").AddFunc("confirmPassword", "密码不一致").ToOptionItem(),
                ValidationSugar.CreateOptionItem().Set("sex", true, "性别").AddRegex("0|1", "值不正确").ToOptionItem(),
               ValidationSugar.CreateOptionItem().Set("email", true, "邮箱").Add(ValidationSugar.OptionItemType.Mail, "邮箱格式不正确").ToOptionItem(),
               ValidationSugar.CreateOptionItem().Set("mobile", false, "手机").Add(ValidationSugar.OptionItemType.Mobile, "手机格式不正确").ToOptionItem(),
               ValidationSugar.CreateOptionItem().Set("qq", false, "qq").AddRegex(@"\d{4,15}", "qq号码格式不正确").ToOptionItem(),
               ValidationSugar.CreateOptionItem().Set("education", true, "学历", true/*checkbox 多选模式*/).AddRegex(@"\d{1,15}", "值不正确").ToOptionItem()
               );
        }
    }
}