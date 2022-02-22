using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Data;
using System.DirectoryServices.Protocols;
using System.Net;

using Siloam.Ui.LasaMedication.App_Code.Models;
using Siloam.Ui.LasaMedication.App_Code.Controller;
using Siloam.Ui.LasaMedication.App_Code.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.UI;
using System.Configuration;


public partial class Login_page : System.Web.UI.Page
{

	protected global::System.Web.UI.HtmlControls.HtmlGenericControl pError;
	protected global::System.Web.UI.WebControls.Label LabelChangePassTitle;
	protected global::System.Web.UI.HtmlControls.HtmlIframe iframechangepass;


	protected void Page_Load(object sender, EventArgs e)
	{

		DataTable dt_login = (DataTable)Session[Helper.Session_DataLogin];

		if (dt_login != null)
		{
			Response.Redirect("~/Pages/dashboard.aspx", false);
		}

	}

	//fungsi klik button login
	protected void btnSignIn_Click(object sender, EventArgs e)
	{

		string usernameLogin = txtUsername.Text.ToString().Replace('\\', '+');
		string passwordLogin = txtPassword.Text.ToString();

		List<ViewLoginUser> ListLoginData = new List<ViewLoginUser>();
		var GetLogin = clsLoginUser.GetLogin(usernameLogin, passwordLogin);
		var GetDataLogin = JsonConvert.DeserializeObject<Result_login_user>(GetLogin.Result.ToString());

		ListLoginData = GetDataLogin.list;

		var Result = ListLoginData[0];
		if (Result.Code == 200)
		{
			DataTable dt_login = Helper.ToDataTable(ListLoginData);
			Session[Helper.Session_DataLogin] = dt_login;
			Response.Redirect("~/Pages/dashboard.aspx", false);
		}
		else
		{
			ScriptManager.RegisterStartupScript(Page, Page.GetType(), "alertpassexpired", "alert('" + Result.Message + "');", true);
		}
	}
}
