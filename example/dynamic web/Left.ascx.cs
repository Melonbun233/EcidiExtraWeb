using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using DBBase;

public partial class Left : System.Web.UI.UserControl
{
    public static string catagory;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            catagory = "";
            GetCatagoryList();
        }
    }

    protected void GetCatagoryList()
    {
        string strSQL = "select title,link from " + Base.CatalogInfo + " where catalogid='12' order by recorddate desc,pkid desc";
        DataTable dt = Base.ExecuteSql4Dt(strSQL);
        if (dt.Rows.Count != 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                string strUrl = row["link"].ToString();
                if (strUrl.IndexOf("?") != -1)
                    strUrl += "&X1=" + Common.Utils.GetCookie("partyconstruction", "X1") + "&X2=" + Common.Utils.GetCookie("partyconstruction", "X2");
                else
                    strUrl += "?X1=" + Common.Utils.GetCookie("partyconstruction", "X1") + "&X2=" + Common.Utils.GetCookie("partyconstruction", "X2");
                catagory += "<li><a href=\"javascript:openwin('" + strUrl + "')\">" + row["title"].ToString() + "</a></li>";
            }
        }
        else
        {
            catagory = "暂无内容";
        }
    }
}
