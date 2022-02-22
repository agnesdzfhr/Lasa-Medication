using Siloam.Ui.LasaMedication.App_Code.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Dashboard : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
        if (!IsPostBack)
        {
            DataTable dt_login = (DataTable)Session[Helper.Session_DataLogin];
            if (dt_login != null)
            {
                UserId.Text = dt_login.Rows[0]["userId"].ToString();
            }
            else
            {
                Response.Redirect("~/Pages/Login_page.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

    }
}