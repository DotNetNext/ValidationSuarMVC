using SyntacticSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ValidationSuarMVC.Models;

public partial class demo2_v2 : System.Web.UI.Page
{
    private string _pageKey = "v2.aspx";
    protected string bindScript = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //请在 Global  applicationStart添加  Validates.Init()
            ViewState["validationBind"] = ValidationSugar.GetBindScript(PageKeys.LOGIN_KEY);
        }
    }


    
}